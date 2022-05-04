using System;
using System.Linq;



namespace LedController.Controller.Infrastructure.Services;

public interface IFileService
{
    /// <summary>
    /// Saves the current buffer to the path specified.
    /// </summary>
    /// <param name="buffer"> The data that we want to save. </param>
    /// <param name="path"> The path that we want ot send it to. </param>
    /// <param name="token"> A token for cancelling the current operation. </param>
    /// <returns> </returns>
    Task SaveFileAsync(ReadOnlyMemory<byte> buffer, string path, CancellationToken token = default);


    /// <summary>
    /// Opens a file into a buffer that we have specified.
    /// </summary>
    /// <param name="path"> The path of where the file is. </param>
    /// <param name="token"> A token for stopping the current operation. </param>
    /// <returns> </returns>
    Task<ReadOnlyMemory<byte>> OpenFileAsync(string path, CancellationToken token = default);
}