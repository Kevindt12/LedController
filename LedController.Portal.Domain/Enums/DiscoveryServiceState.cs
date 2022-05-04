using System;
using System.Linq;



namespace LedController.WebPortal.Domain.Enums;

/// <summary>
/// The status of the discovery service.
/// </summary>
public enum DiscoveryServiceState
{
	/// <summary>
	/// The service has stopped.
	/// </summary>
	Stopped,

	/// <summary>
	/// The service is in the progress of stopping.
	/// </summary>
	Stopping,

	/// <summary>
	/// The service is in the progress of starting.
	/// </summary>
	Starting,


	/// <summary>
	/// The service is running.
	/// </summary>
	Running
}