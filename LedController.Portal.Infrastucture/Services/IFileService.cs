using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Infrastructure.Services;

/// <summary>
/// The file service responsible for handing everything to do with the file system.
/// </summary>
public interface IFileService
{
	/// <summary>
	/// Saves a assembly file to disk.
	/// </summary>
	/// <param name="file"> The file we want to save. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task SaveAssemblyFileAsync(EffectAssembly effectAssembly, ReadOnlyMemory<byte> file, CancellationToken token = default);


	/// <summary>
	/// Opens a assembly file that was saved to disk.
	/// </summary>
	/// <param name="id"> </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task<ReadOnlyMemory<byte>> OpenAssemblyAsync(EffectAssembly effectAssembly, CancellationToken token = default);


    /// <summary>
    /// Checks if there is a file on the given path.
    /// </summary>
    /// <param name="filePath"> The path that we want to check. </param>
    /// <returns> </returns>
    bool FileExists(string filePath);
}