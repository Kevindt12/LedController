using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The manager that handles everything to do with handling effect objects.
/// </summary>
public interface IEffectStore : IStore<Effect>
{
    /// <summary>
    /// Removes a effect parameter from the application.
    /// </summary>
    /// <param name="effectParameter"> The effect parameter that we want to remove. </param>
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    Task RemoveEffectParameterAsync(EffectParameter effectParameter, CancellationToken token = default);
}