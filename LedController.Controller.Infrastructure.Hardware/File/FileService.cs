using System;
using System.Linq;

using LedController.Controller.Infrastructure.Services;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Infrastructure.Device.File;

public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;


    /// <summary>
    /// The file service that is resposible for thi
    /// </summary>
    /// <param name="logger"> </param>
    /// <param name="fileService"> </param>
    public FileService(ILogger<FileService> logger)
    {
        _logger = logger;
    }


    /// <inheritdoc />
    public async Task SaveFileAsync(ReadOnlyMemory<byte> buffer, string path, CancellationToken token = default)
    {
        _logger.LogTrace($"Saving file to path {path}.");

        FileStream stream = new FileStream(path, FileMode.CreateNew);

        try
        {
            await stream.WriteAsync(buffer, token);
            await stream.FlushAsync(token);
            _logger.LogTrace("Done writing file to disk.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a error with saving a file.");

            throw;
        }
        finally
        {
            await stream.DisposeAsync();
        }

        _logger.LogTrace("File was saved successfully.");
    }


    /// <inheritdoc />
    /// <exception cref="FileNotFoundException"> thrown when we cant find the file. </exception>
    public async Task<ReadOnlyMemory<byte>> OpenFileAsync(string path, CancellationToken token = default)
    {
        _logger.LogTrace($"Opening file at {path}.");

        if (!System.IO.File.Exists(path)) throw new FileNotFoundException("Cannot find the file", path);

        FileStream stream = new FileStream(path, FileMode.Open);
        Memory<byte> buffer = new Memory<byte>();

        try
        {
            await stream.ReadAsync(buffer, token);
            _logger.LogTrace("Done reading file from disk.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a error with reading a file.");

            throw;
        }
        finally
        {
            await stream.DisposeAsync();
        }

        _logger.LogTrace("File was read successfully.");

        return buffer;
    }
}