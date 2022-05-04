using System;
using System.Linq;

using LedController.WebPortal.Domain.Enums;
using LedController.WebPortal.Domain.Models;

using Microsoft.Extensions.Hosting;



namespace LedController.WebPortal.Domain.Services;

/// <summary>
/// The service that handles the automatic discovery of controllers.
/// </summary>
public interface IDiscoveryService : IHostedService
{
	/// <summary>
	/// A event that will be thrown if a controller has been discovered.
	/// </summary>
	event EventHandler<ControllerDiscoveredEventArgs> ControllerDiscovered;


	/// <summary>
	/// The state of the discovery service has changed.
	/// </summary>
	event EventHandler<DiscoveryStateChangedEventArgs> StateChanged;


	/// <summary>
	/// The state of the service.
	/// </summary>
	public DiscoveryServiceState State { get; set; }


	/// <summary>
	/// The discovery port.
	/// </summary>
	public ushort DiscoveryPort { get; }


	/// <summary>
	/// Gets if the discovery service is running.
	/// </summary>
	/// <returns> </returns>
	bool IsDiscoveryRunning();


	/// <summary>
	/// Restarts the discovery service.
	/// </summary>
	/// <returns> </returns>
	Task RestartAsync(CancellationToken token = default);


	/// <summary>
	/// Changes the port that we use to broadcast the messages to the network
	/// </summary>
	/// <param name="port"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task ChangePortAsync(ushort port, CancellationToken token = default);
}



public class ControllerDiscoveredEventArgs : EventArgs
{
	/// <summary>
	/// The arguments that we have for a controller that we have found.
	/// </summary>
	/// <param name="controller"> </param>
	public ControllerDiscoveredEventArgs(Controller controller)
	{
		Controller = controller;
	}


	/// <summary>
	/// The controller we have found.
	/// </summary>
	public Controller Controller { get; init; }
}



public class DiscoveryStateChangedEventArgs : EventArgs
{
	/// <summary>
	/// The new state that the discovery service.
	/// </summary>
	public DiscoveryServiceState NewState { get; init; }


	/// <summary>
	/// The event args for the state that is chagned for the service.
	/// </summary>
	/// <param name="newState"> </param>
	public DiscoveryStateChangedEventArgs(DiscoveryServiceState newState)
	{
		NewState = newState;
	}
}