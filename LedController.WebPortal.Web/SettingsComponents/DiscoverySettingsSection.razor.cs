using System;
using System.Linq;

using LedController.WebPortal.Domain.Enums;
using LedController.WebPortal.Domain.Services;

using Microsoft.AspNetCore.Components;

using MudBlazor;



namespace LedController.WebPortal.Web.SettingsComponents;

public partial class DiscoverySettingsSection : ComponentBase
{
	/// <summary>
	/// The port that we use for discovering a new controllers.
	/// </summary>
	public ushort DiscoveryPort { get; set; }


	public DiscoveryServiceState ServiceState { get; set; }


	[Inject]
	public ILogger<DiscoverySettingsSection>? Logger { get; set; }

	[Inject]
	public IDiscoveryService? DiscoveryService { get; set; }

	[Inject]
	public ISnackbar? Snackbar { get; set; }


	public bool IsServiceStateIsInChangingPhase { get; set; }


	public bool IsServiceStatIsRunning { get; set; }


	/// <inheritdoc />
	protected override Task OnInitializedAsync()
	{
		DiscoveryService!.StateChanged += DiscoveryServiceOnStateChanged;

		DiscoveryPort = DiscoveryService!.DiscoveryPort;

		return base.OnInitializedAsync();
	}


	private void DiscoveryServiceOnStateChanged(object? sender, DiscoveryStateChangedEventArgs e)
	{
		// Changes the binding booleans that control view.
		switch (e.NewState)
		{
			case DiscoveryServiceState.Stopping:
				IsServiceStateIsInChangingPhase = true;
				IsServiceStatIsRunning = true;

				break;
			case DiscoveryServiceState.Stopped:
				IsServiceStateIsInChangingPhase = false;
				IsServiceStatIsRunning = false;

				break;
			case DiscoveryServiceState.Running:
				IsServiceStatIsRunning = true;
				IsServiceStateIsInChangingPhase = false;

				break;
			case DiscoveryServiceState.Starting:
				IsServiceStatIsRunning = false;
				IsServiceStateIsInChangingPhase = true;

				break;
			default: throw new ArgumentOutOfRangeException(nameof(e.NewState), "The state of the discovery service is not a valid state.");
		}

		ServiceState = e.NewState;
	}


	private async Task OnDiscoveryPortChangedAsync()
	{
		if (ValidatePort(DiscoveryPort)) return;

		await DiscoveryService!.ChangePortAsync(DiscoveryPort);

		Snackbar!.Add("Changes are saved.", Severity.Success);
	}


	/// <summary>
	/// Check if the port that we have selected is valid.
	/// </summary>
	/// <param name="port"> The port that has changed. </param>
	/// <returns> </returns>
	protected virtual bool ValidatePort(ushort port)
	{
		// TODO: Implment that we check that we are using a port that can be used.

		return true;
	}


	protected virtual async Task StartServiceAsync()
	{
		await DiscoveryService!.StartAsync(CancellationToken.None);

		Snackbar!.Add("Discovery Service Started", Severity.Success);
	}


	protected virtual async Task StopServiceAsync()
	{
		await DiscoveryService!.StopAsync(CancellationToken.None);

		Snackbar!.Add("Discovery Service Stopped", Severity.Success);
	}
}