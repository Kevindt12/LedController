using System;
using System.Linq;

using LedController.Shared.Attributes;



namespace LedController.WebPortal.Domain.Options;

[Option("Discovery Options")]
public class DiscoveryOptions
{
	/// <summary>
	/// The port that we will use for finding new controllers.
	/// </summary>
	public ushort DiscoveryPort { get; set; }


	/// <summary>
	/// The period that we will wait before we do a other broadcast.
	/// </summary>
	public TimeSpan BroadcastTime { get; set; }


	/// <summary>
	/// The options for the discovery service.
	/// </summary>
	public DiscoveryOptions() { }
}