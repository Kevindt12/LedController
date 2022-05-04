using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// The effects manager.
/// </summary>
public interface IEffectManager : IManager<Effect>
{
	/// <summary>
	/// Removes the sync from all the controllers so we need to resync the effects again with each controller.
	/// </summary>
	/// <param name="effect"> </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task UnSyncEffectFromAllControllers(Effect effect, CancellationToken token = default);


	/// <summary>
	/// Adds a effect parameter to a effect.
	/// </summary>
	/// <param name="effect"> The effect that we are adding. </param>
	/// <param name="effectParameter"> The effect parameter that we are adding. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task AddEffectParameterAsync(Effect effect, EffectParameter effectParameter, CancellationToken token = default);


	/// <summary>
	/// Removing effect parameter from a effect.
	/// </summary>
	/// <param name="effect"> The effect that we want to remove fa parameter from. </param>
	/// <param name="effectParameter"> The effect parameter that we want to remove. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task RemoveEffectParameterAsync(Effect effect, EffectParameter effectParameter, CancellationToken token = default);
}