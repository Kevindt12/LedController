using System;
using System.Linq;

using LedController.Domain.Models;

using UnitsNet;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// The manager that handles all the animations of the application.
/// </summary>
public interface IAnimationManager : IManager<Animation>
{
	/// <summary>
	/// Creates a new animation and attaches that animation to the store.
	/// </summary>
	/// <param name="animation"> The animation we want to store. </param>
	/// <param name="effect"> The animationEffect effect we want to use. </param>
	/// <param name="duration"> </param>
	/// <param name="frequency"> </param>
	/// ///
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task CreateAnimationEffectAsync(Animation animation,
									Effect effect,
									TimeSpan? duration,
									Frequency frequency,
									CancellationToken token = default);


	/// <summary>
	/// Updates an animation effects effect.
	/// </summary>
	/// <param name="animationEffect"> </param>
	/// <param name="effect"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task UpdateAnimationEffectAsync(AnimationEffect animationEffect, Effect effect, CancellationToken token = default);


	/// <summary>
	/// Removes a animationEffect from the animation
	/// </summary>
	/// <param name="animation"> The animation we want to remove the animationEffect from. </param>
	/// <param name="animationEffect"> The animationEffect we want to remove. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task RemoveAnimationEffectAsync(Animation animation, AnimationEffect animationEffect, CancellationToken token = default);


	/// <summary>
	/// Creates a copy of a animation with a new name.
	/// </summary>
	/// <param name="animation"> The animation we want to copy </param>
	/// <param name="newName"> The new name of the animation. </param>
	/// <returns> </returns>
	Animation CopyAnimation(Animation animation, string newName);


	/// <summary>
	/// Updates un array of animation effect parameter values.
	/// </summary>
	/// <param name="parameters"> </param>
	/// <returns> </returns>
	Task UpdateAnimationEffectParameterValuesAsync(IEnumerable<AnimationEffectParameterValue> parameters, CancellationToken token = default);
}