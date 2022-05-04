using System;
using System.Reflection;
using System.Linq;
using System.Text.Json;

using LedController.Shared.Attributes;
using LedController.WebPortal.Domain.Managers;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

public class ConfigurationManager : IConfigurationManager
{
	private readonly ILogger<ConfigurationManager> _logger;


	public ConfigurationManager(ILogger<ConfigurationManager> logger)
	{
		_logger = logger;
	}


	/// <inheritdoc />
	public async Task UpdateOptions<T>(T option, CancellationToken token = default)
	{
		string sectionKey = option!.GetType().GetCustomAttribute<OptionAttribute>()?.Name
							?? throw new InvalidOperationException("Cannot save options from a class that is not a options class.");

		_logger.LogDebug($"Updating the settings for {sectionKey}.");

		try
		{
			string filePath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
			string json = await File.ReadAllTextAsync(filePath, token);
			dynamic jsonObj = JsonSerializer.Deserialize<T>(json)!;

			// Write the option to the options section that we have the key from.
			jsonObj[sectionKey] = option;

			string output = JsonSerializer.Serialize(jsonObj,
													 new JsonSerializerOptions
													 {
														 WriteIndented = true
													 });

			await File.WriteAllTextAsync(filePath, output, token);

			_logger.LogDebug("Saving the new settings has been successful.");
		}
		catch (JsonException ex)
		{
			_logger.LogError(ex, "There was a problem with the JSON Serialization for updating the settings file.");
		}
	}
}