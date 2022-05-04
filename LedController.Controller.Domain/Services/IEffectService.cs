using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Services;

/// <summary>
/// All the action that we can take with effects.
/// </summary>
public interface IEffectService
{
    /// <summary>
    /// Saves the effect to disk to be used in the application.
    /// </summary>
    /// <param name="buffer"> The buffer containing the assembly file. </param>
    /// <param name="effectAssembly"> Effect assembly that we want to save. </param>
    /// <returns> </returns>
    Task SaveEffectAssembly(ReadOnlyMemory<byte> buffer, EffectAssembly effectAssembly, CancellationToken token = default);
}