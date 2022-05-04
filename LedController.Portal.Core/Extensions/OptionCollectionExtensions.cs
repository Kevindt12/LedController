using System;
using System.Linq;

using LedController.Shared.Options;
using LedController.WebPortal.Domain.Options;

using FileOptions = LedController.WebPortal.Domain.Options.FileOptions;



namespace LedController.WebPortal.Core.Extensions;

public static class OptionCollectionExtensions
{
	/// <summary>
	/// Adds the core application options.
	/// </summary>
	/// <param name="options"> The options collection that we need to add the options. </param>
	/// <returns> </returns>
	public static IOptionsCollection AddCoreOptions(this IOptionsCollection options)
	{
		options.AddOption<DiscoveryOptions>();
		options.AddOption<FileOptions>();

		return options;
	}
}