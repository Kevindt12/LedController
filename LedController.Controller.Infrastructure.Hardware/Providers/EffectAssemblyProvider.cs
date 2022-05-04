using System;
using System.Linq;
using System.Reflection;

using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Options;
using LedController.Controller.Infrastructure.Providers;
using LedController.Controller.Infrastructure.Services;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;



namespace LedController.Controller.Infrastructure.Device.Providers;

internal class EffectAssemblyProvider : IEffectAssemblyProvider
{
	private readonly ILogger<EffectAssemblyProvider> _logger;
	private readonly IFileService _fileService;
	private readonly DeviceOptions _deviceOptions;

	protected AppDomain AppDomain { get; set; }


	public EffectAssemblyProvider(ILogger<EffectAssemblyProvider> logger, IFileService fileService, IOptions<DeviceOptions> deviceOptions)
	{
		_logger = logger;
		_fileService = fileService;
		_deviceOptions = deviceOptions.Value;
		AppDomain = AppDomain.CurrentDomain;
	}


	/// <inheritdoc />
	public virtual async ValueTask<Assembly> GetAssemblyAsync(EffectAssembly effectAssembly, CancellationToken token = default)
	{
		string path = ComposeFileName(effectAssembly);

		_logger.LogTrace($"Checking if assembly {path} is already loaded.");

		if (AppDomain.GetAssemblies().Where(x => x.IsDynamic == false).Any(x => x.Location == path))
		{
			_logger.LogTrace("Assembly still loaded.");

			return AppDomain.GetAssemblies().Single(x => x.Location == path)!;
		}

		// Loading assembly.
		try
		{
			_logger.LogTrace("Assembly is not loaded attempting to load assembly.");

			ReadOnlyMemory<byte> assemblyFileBuffer = await _fileService.OpenFileAsync(path, token);

			return AppDomain.Load(assemblyFileBuffer.ToArray());
		}
		catch (FileNotFoundException fileNotFoundException)
		{
			_logger.LogError(fileNotFoundException, $"Tried to get file {path} but was unsuccessful.");

			throw new AnimationException($"There was no effect assembly found for this effect. Assembly : {effectAssembly.Id}.", fileNotFoundException);
		}
		catch (BadImageFormatException badImageFormatException)
		{
			_logger.LogError(badImageFormatException, $"Could not load assembly for {effectAssembly.Id}.");

			throw;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "There was a problem with loading the assembly.");

			throw;
		}
	}


	/// <inheritdoc />
	public virtual Task SaveAssemblyAsync(EffectAssembly effectAssembly, ReadOnlyMemory<byte> buffer, CancellationToken token = default)
	{
		CreateDirectoryIfNotExists();

		string path = ComposeFileName(effectAssembly);
		_logger.LogTrace($"Saving assembly {effectAssembly.Id} to {path}.");

		return _fileService.SaveFileAsync(buffer, path, token);
	}


	/// <summary>
	/// Checks if the directory exists if not it will create the directory.
	/// </summary>
	private void CreateDirectoryIfNotExists()
	{
		string directory = Path.Combine(Environment.CurrentDirectory, _deviceOptions.AssemblyDirectory);

		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
	}


	/// <summary>
	/// Composes the path to the assemblies. Or create the path of none exist.
	/// </summary>
	/// <param name="effectAssembly"> The effect assembly that we want to create a full path for. </param>
	/// <returns> </returns>
	protected virtual string ComposeFileName(EffectAssembly effectAssembly)
	{
		// Creating full name.
		string fullName = Path.Combine(Environment.CurrentDirectory, _deviceOptions.AssemblyDirectory, effectAssembly.GenerateFileName());
		;
		_logger.LogTrace($"Creating full file name for assembly FullName will be {fullName}.");

		return fullName;
	}
}