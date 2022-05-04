using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Infrastructure.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using FileOptions = LedController.WebPortal.Domain.Options.FileOptions;



namespace LedController.WebPortal.Infrastructure.Connections.Services;

internal class FileService : IFileService
{
	private readonly ILogger<FileService> _logger;
	private readonly IWebHostEnvironment _webHostEnvironment;

	private readonly FileOptions _options;


	public FileService(ILogger<FileService> logger, IOptions<FileOptions> fileOptions, IWebHostEnvironment webHostEnvironment)
	{
		_logger = logger;
		_webHostEnvironment = webHostEnvironment;

		_options = fileOptions.Value;
	}


	/// <inheritdoc />
	public async Task SaveAssemblyFileAsync(EffectAssembly effectAssembly, ReadOnlyMemory<byte> file, CancellationToken token = default)
	{
		CreateAssemblyFolderIfNotExist();
		string absolutePath = CreateAssemblyFilePath(effectAssembly.GenerateFileName());
		_logger.LogTrace($"Starting operation to save effect assembly {effectAssembly.Id} to {absolutePath}.");

		await using FileStream stream = File.Open(absolutePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

		await stream.WriteAsync(file, token);
		await stream.FlushAsync(token);
		_logger.LogTrace("Done writing file.");
	}


	/// <inheritdoc />
	public async Task<ReadOnlyMemory<byte>> OpenAssemblyAsync(EffectAssembly effectAssembly, CancellationToken token = default)
	{
		CreateAssemblyFolderIfNotExist();
		string absolutePath = CreateAssemblyFilePath(effectAssembly.GenerateFileName());
		_logger.LogTrace($"Starting operation to read effect assembly {effectAssembly.Id} from {absolutePath}.");

		await using FileStream stream = File.Open(absolutePath, FileMode.Open, FileAccess.Read);

		Memory<byte> buffer = new Memory<byte>();
		int bytesRead = await stream.ReadAsync(buffer, token);
		_logger.LogTrace($"Done reading from file. Bytes read from file {bytesRead}");

		return buffer;
	}


	/// <summary>
	/// Creates the path of the assemblies and the file names
	/// </summary>
	/// <param name="fileName"> The file name of the assembly. </param>
	/// <returns> </returns>
	protected virtual string CreateAssemblyFilePath(string fileName)
	{
		return $"{_webHostEnvironment.ContentRootPath}{_options.AssemblyDirectory}{Path.DirectorySeparatorChar}{fileName}.dll";
	}


	/// <summary>
	/// Creates a assembly folder if none exists.
	/// </summary>
	protected virtual void CreateAssemblyFolderIfNotExist()
	{
		string path = $"{_webHostEnvironment.ContentRootPath}{Path.DirectorySeparatorChar}{_options.AssemblyDirectory}";

		if (!Directory.Exists(path))
		{
			_logger.LogWarning($"Path to : {path} does not exist. Creating folder!");

			Directory.CreateDirectory(path);
		}
	}


	/// <inheritdoc />
	public bool FileExists(string filePath)
	{
		return File.Exists(filePath);
	}
}