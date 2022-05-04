using System;
using System.Linq;

using LedController.Domain.Models;

using Microsoft.Extensions.Logging;

using UnitsNet;



namespace LedController.WebPortal.Core.Factories;

public class AnimationFactory
{
	private readonly ILogger<AnimationFactory> _logger;


	/// <summary>
	/// The factory that provides utility to create animations.
	/// </summary>
	public AnimationFactory(ILogger<AnimationFactory> logger)
	{
		_logger = logger;
	}


	/// <summary>
	/// Creates a copy of the animation given
	/// </summary>
	/// <param name="originalAnimation"> </param>
	/// <returns> </returns>
	public virtual Animation CopyAnimation(Animation originalAnimation)
	{
		_logger.LogTrace("Creating copy of animation.");
		Animation animation = new Animation();

		animation.Name = $"{originalAnimation.Name} - Copy";
		_logger.LogTrace($"New animation name is {animation.Name}");

		foreach (AnimationEffect animationEffect in originalAnimation.Effects)
		{
			AnimationEffect cloneEffect = new AnimationEffect
			{
				Animation = animation,
				Effect = animationEffect.Effect
			};

			foreach (AnimationEffectParameterValue originalParameter in animationEffect.Parameters)
			{
				cloneEffect.Parameters.Add(new AnimationEffectParameterValue
				{
					Name = originalParameter.Name,
					Value = originalParameter.Value
				});
			}

			animation.Effects.Add(cloneEffect);
		}

		_logger.LogTrace("Done with copy of animation.");

		return animation;
	}


	/// <summary>
	/// Adds a effect to a animation.
	/// </summary>
	/// <param name="animation"> The effect that we want to add. </param>
	/// <param name="effect"> The effect that we want to add to the animation. </param>
	/// <returns> </returns>
	public virtual AnimationEffect CreateAnimationEffect(Animation animation,
														 Effect effect,
														 Frequency frequency,
														 TimeSpan? duration)
	{
		// Creates a new animation effect. Also setting the default value for the effects.
		AnimationEffect animationEffect = new AnimationEffect
		{
			Animation = animation,
			Effect = effect,
			Frequency = frequency,
			Duration = duration,
			Parameters = effect.Parameters.Select(x => new AnimationEffectParameterValue
								{
									Name = x.Name,
									Value = x.DefaultValue
								})
							   .ToList()
		};

		// Adding the animation effect to the animation.
		animation.Effects.Add(animationEffect);

		return animationEffect;
	}
}