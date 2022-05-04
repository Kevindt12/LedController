using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using LedController.WebPortal.Domain.Enums;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Options;
using LedController.WebPortal.Domain.Services;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



namespace LedController.WebPortal.Core.Services;

internal class DiscoveryService : BackgroundService, IDiscoveryService, IDisposable
{
	private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
	private static readonly SemaphoreSlim _restartSemaphoreSlim = new SemaphoreSlim(1, 1);


	private readonly ILogger<DiscoveryService> _logger;
	private readonly IConfigurationManager _configurationManager;
	private readonly IDisposable _discoveryOptionsCallbackHolder;

	private DiscoveryServiceState _state;

	/// <inheritdoc />
	public event EventHandler<ControllerDiscoveredEventArgs>? ControllerDiscovered;

	/// <inheritdoc />
	public event EventHandler<DiscoveryStateChangedEventArgs>? StateChanged;


	/// <inheritdoc />
	public DiscoveryServiceState State
	{
		get => _state;
		set
		{
			_state = value;
			StateChanged?.Invoke(this, new DiscoveryStateChangedEventArgs(value));
		}
	}


	/// <summary>
	/// The udp client that will broadcast that we exist to the network.
	/// </summary>
	protected virtual UdpClient? UdpClient { get; set; }

	/// <summary>
	/// The port that we are broadcasting the messages on.
	/// </summary>
	public ushort DiscoveryPort => Options.DiscoveryPort;


	/// <summary>
	/// The options that we use to select how we broadcast.
	/// </summary>
	protected virtual DiscoveryOptions Options { get; set; }


	/// <summary>
	/// The service that runs the discovery of the controllers.
	/// </summary>
	public DiscoveryService(ILogger<DiscoveryService> logger, IConfigurationManager configurationManager, IOptionsMonitor<DiscoveryOptions> discoveryOptionsMonitor)
	{
		_logger = logger;
		_configurationManager = configurationManager;
		Options = discoveryOptionsMonitor.CurrentValue;

		State = DiscoveryServiceState.Stopped;

		_discoveryOptionsCallbackHolder = discoveryOptionsMonitor.OnChange(o => Options = o);
	}


	/// <summary>
	/// Setting up the UDP client to connect.
	/// </summary>
	/// <returns> A configured UDP client that is ready to be used. </returns>
	protected virtual UdpClient SetupClient(ushort port)
	{
		_logger.LogDebug($"Creating a new UDP client to be used for broadcasting the server information. This wil happen on UDP port {port}.");

		// Creates a new client that will be used to communicate with the rest of the network to find any clients that might want to connect.
		UdpClient client = new UdpClient(port);

		// Allowing the client ot send broadcast messages to the network.
		client.EnableBroadcast = true;

		return client;
	}


	/// <inheritdoc />
	public bool IsDiscoveryRunning()
	{
		return base.ExecuteTask != null;
	}


	/// <inheritdoc />
	public async Task RestartAsync(CancellationToken token = default)
	{
		await _restartSemaphoreSlim.WaitAsync(token);

		try
		{
			if (State == DiscoveryServiceState.Running)
			{
				await StopAsync(token);

				if (State == DiscoveryServiceState.Stopped) await StartAsync(token);
			}
		}
		catch (Exception e)
		{
			_logger.LogError("There was a error restarting the discovery service.");

			throw;
		}
		finally
		{
			_restartSemaphoreSlim.Release();
		}
	}


	/// <inheritdoc />
	public async Task ChangePortAsync(ushort port, CancellationToken token = default)
	{
		Options.DiscoveryPort = port;

		await _configurationManager.UpdateOptions(Options, token);

		// Only restart if the service is running else just leave it.
		if (IsDiscoveryRunning()) return;
		await RestartAsync(token);
	}


	/// <inheritdoc />
	public override async Task StartAsync(CancellationToken cancellationToken)
	{
		await _semaphore.WaitAsync(cancellationToken);

		try
		{
			// Checking if we are restarting. If its is restarting we don't change the state.
			if (State != DiscoveryServiceState.Stopped) throw new InvalidOperationException("The discovery client is already running therefore we can not start the service again,");

			State = DiscoveryServiceState.Starting;
			_logger.LogDebug("Starting the discovery service.");

			// Starting the service.
			UdpClient = SetupClient(Options.DiscoveryPort);
			await base.StartAsync(cancellationToken);

			State = DiscoveryServiceState.Running;
			_logger.LogDebug("The discovery service has started.");
		}
		catch (Exception e)
		{
			UdpClient?.Dispose();
			UdpClient = null;

			_logger.LogError(e, "There was a problem with starting the discovery service.");

			throw;
		}
		finally
		{
			_semaphore.Release();
		}
	}


	/// <inheritdoc />
	public override async Task StopAsync(CancellationToken cancellationToken)
	{
		await _semaphore.WaitAsync(cancellationToken);

		try
		{
			if (State != DiscoveryServiceState.Running) throw new InvalidOperationException("Cannot stop a stopped discovery service.");

			State = DiscoveryServiceState.Stopping;
			_logger.LogDebug("Stopping the discovery service.");

			// First do its normal stopping then we will stop the client.
			await base.StopAsync(cancellationToken);

			State = DiscoveryServiceState.Stopped;
			_logger.LogDebug("The discovery service has stopped.");
		}
		catch (Exception e)
		{
			_logger.LogError(e, "There was a problem with stopping the discovery service.");
		}
		finally
		{
			// Disposing of the UDP client.
			UdpClient?.Dispose();
			UdpClient = null;

			_semaphore.Release();
		}
	}


	/// <inheritdoc />
	protected override async Task ExecuteAsync(CancellationToken stoppingToken = default)
	{
		// Making sure this does not run on the main thread.
		await Task.Yield();

		// Using a periodic timer to send messages because it will await in the background.
		using PeriodicTimer timer = new PeriodicTimer(Options.BroadcastTime);

		_logger.LogTrace("Start sending message to controllers to be discovered.");

		while (await timer.WaitForNextTickAsync(stoppingToken))
		{
			// Send the message that we want to discover a controller.
			await SendDiscoveryMessageAsync(stoppingToken);
		}

		_logger.LogTrace("Stopped sending message to controllers to find them.");
	}


	/// <summary>
	/// Broadcasts a message to the network to find any new controllers.
	/// </summary>
	/// <param name="token"> The token to cancel the current operation. </param>
	/// <returns> </returns>
	protected virtual async Task SendDiscoveryMessageAsync(CancellationToken token = default)
	{
		await UdpClient!.SendAsync(CreateBroadcastMessage(), token);

		_logger.LogTrace($"Sending discovery message to network on port {Options.DiscoveryPort}.");
	}


	/// <summary>
	/// Creates the message that we want to send to the controllers.
	/// </summary>
	/// <remarks>
	/// The message frame is as following.
	/// [ IPAddress (4 bytes), Port (2 bytes )  ]
	/// </remarks>
	/// <returns> </returns>
	protected virtual ReadOnlyMemory<byte> CreateBroadcastMessage()
	{
		// Get the current IP Address.
		IPAddress address = GetHostIpAddress();
		ushort port = Convert.ToUInt16(Options.DiscoveryPort);

		// Adding the data to a array so we have the data to send.
		byte[] data = new byte[5];
		address.GetAddressBytes().CopyTo(data, 0);
		BitConverter.GetBytes(port).CopyTo(data, 4);

		return data;
	}


	// TODO: Make this neat this cannot be just give me the first local network and hope it works.


	/// <summary>
	/// Gets the local host IP address.
	/// </summary>
	/// <returns> A IP address of the first local network found. </returns>
	/// <exception cref="InvalidOperationException"> If the server has no local network connected. </exception>
	protected virtual IPAddress GetHostIpAddress()
	{
		IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
		IPAddress[] addresses = ipEntry.AddressList;

		foreach (IPAddress address in addresses)
		{
			if (address.AddressFamily == AddressFamily.InterNetwork) return address;
		}

		throw new InvalidOperationException("No local ip address was found.");
	}


	/// <summary>
	/// Disposing of resources.
	/// </summary>
	protected virtual void Dispose(bool disposing)
	{
		if (disposing) UdpClient?.Dispose();
	}


	/// <inheritdoc />
	public override void Dispose()
	{
		// First run our disposable then run the background service disposable.
		Dispose(true);
		base.Dispose();

		GC.SuppressFinalize(this);
	}
}