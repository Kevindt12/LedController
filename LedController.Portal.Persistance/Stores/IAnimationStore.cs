using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The animations in the application.
/// </summary>
public interface IAnimationStore : IStore<Animation>
{
	/// <summary>
	/// Adds an animation effect to an animation.
	/// </summary>
	/// <param name="animationEffect"> The effect that we want to add. </param>
	/// <returns> </returns>
	void AddAnimationEffect(AnimationEffect animationEffect);


	/// <summary>
	/// Updates the animation effect.
	/// </summary>
	/// <param name="animationEffect"> </param>
	/// <returns> </returns>
	void UpdateAnimationEffect(AnimationEffect animationEffect);


	/// <summary>
	/// Removes a animation effect from the animation.
	/// </summary>
	/// <param name="animationEffect"> The animation effect that we want to remove. </param>
	/// <returns> </returns>
	void RemoveAnimationEffect(AnimationEffect animationEffect);


	/// <summary>
	/// Updates all the given parameter values.
	/// </summary>
	/// <param name="parameterValues"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	void UpdateAnimationEffectParameterValues(IEnumerable<AnimationEffectParameterValue> parameterValues);


	/// <summary>
	/// Checks if a animation exists.
	/// </summary>
	/// <param name="animation"> The animation that we want to check if it exists. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task<bool> Exists(Animation animation, CancellationToken token = default);
}