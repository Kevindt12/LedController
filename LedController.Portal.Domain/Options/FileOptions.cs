using System;
using System.Linq;

using LedController.Shared.Attributes;



namespace LedController.WebPortal.Domain.Options;

[Option("FileSystem")]
public class FileOptions
{
	/// <summary>
	/// The directory where the assemblies are saved.
	/// </summary>
	public string? AssemblyDirectory { get; set; }
}