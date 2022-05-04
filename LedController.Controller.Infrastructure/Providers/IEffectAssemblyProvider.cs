using System;
using System.Linq;
using System.Reflection;

using LedController.Domain.Models;



namespace LedController.Controller.Infrastructure.Providers;

public interface IEffectAssemblyProvider
{
    /// <summary>
    /// Gets the assembly that is part of the effect assembly.
    /// </summary>
    /// <remarks>
    /// Using value task because we will have a lot of times the assembly already loaded into memory and just need to retreve it.
    /// So there might not be a async operation a lot of the times. But when we have to get from disk we have a async operation.
    /// </remarks>
    /// <param name="effectAssembly"> The effect assembly that we want to load. </param>
    /// <exception cref="FileNotFoundException"> Thrown when the asembly does not have a filename set. This is because we need to get it first from the database. </exception>
    /// <returns> </returns>
    ValueTask<Assembly> GetAssemblyAsync(EffectAssembly effectAssembly, CancellationToken token = default);


    /// <summary>
    /// Saves a assembly onto disk.
    /// </summary>
    /// <param name="effectAssembly"> The assembly that we want to save. </param>
    /// <param name="buffer"> The buffer that contains the assembly. </param>
    /// <param name="token"> A token to cancel the operation. </param>
    /// <returns> </returns>
    Task SaveAssemblyAsync(EffectAssembly effectAssembly, ReadOnlyMemory<byte> buffer, CancellationToken token = default);
}