using System;
using System.Linq;

using LedController.Shared.Attributes;



namespace LedController.Controller.Domain.Options;

[Option("Discovery")]
public class DiscoveryOptions
{
	/// <summary>
	/// The port that we listen to when getting discovery requests.
	/// </summary>
	public short Port { get; set; }
}