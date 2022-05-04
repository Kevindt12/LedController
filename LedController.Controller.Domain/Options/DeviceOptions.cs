using System;
using System.Linq;

using LedController.Shared.Attributes;



namespace LedController.Controller.Domain.Options;

[Option("Device")]
public class DeviceOptions
{
	/// <summary>
	/// The directory where the assemblies are stored.
	/// </summary>
	public string AssemblyDirectory { get; set; }
}