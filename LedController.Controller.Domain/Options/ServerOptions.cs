using System;
using System.Linq;

using LedController.Shared.Attributes;



namespace LedController.Controller.Domain.Options;

[Option("Server")]
public class ServerOptions
{
	/// <summary>
	/// The port that we use to connect and listen for instruction on.
	/// </summary>
	public int Port { get; set; }
}