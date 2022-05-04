using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Core.Factories;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;

using UnitsNet;



namespace LedController.WebPortal.Core.Managers;

internal class AnimationManager : ManagerBase<Animation, IAnimationStore>, IAnimationManager
{
	private readonly ILogger<AnimationManager> _logger;
	private readonly AnimationFactory _animationFactory;


	public AnimationManager(ILoggerFactory loggerFactory,
							ILogger<AnimationManager> logger,
							IRepository repository,
							AnimationFactory animationFactory,
							IAnimationStore store) : base(loggerFactory.CreateLogger<ManagerBase<Animation, IAnimationStore>>(), repository, store)
	{
		_logger = logger;
		_animationFactory = animationFactory;
	}


	/// <inheritdoc />
	public Task CreateAnimationEffectAsync(Animation animation,
										   Effect effect,
										   TimeSpan? duration,
										   Frequency frequency,
										   CancellationToken token = default)
	{
		_logger.LogDebug("Creating animation effect.");

		AnimationEffect animationEffect = new AnimationEffect(effect, animation, frequency, duration);
		animationEffect.Parameters = GenerateAnimationEffectParameterValues(effect).ToList();

		animation.Effects.Add(animationEffect);

		_store.AddAnimationEffect(animationEffect);

		return _repository.SaveChangesAsync(token);
	}


	/// <summary>
	/// Gets a list of parameter values from an effect.
	/// </summary>
	/// <param name="effect"> The effect we want to get animation parameter values from. </param>
	/// <returns> </returns>
	protected virtual IEnumerable<AnimationEffectParameterValue> GenerateAnimationEffectParameterValues(Effect effect)
	{
		return effect.Parameters.Select(parameter => new AnimationEffectParameterValue(parameter.Name, parameter.Id, parameter.DefaultValue));
	}


	/// <inheritdoc />
	public Task UpdateAnimationEffectAsync(AnimationEffect animationEffect, Effect effect, CancellationToken token = default)
	{
		_logger.LogDebug($"updating animation effect {animationEffect.Id}.");

		if (effect != animationEffect.Effect)
		{
			_logger.LogDebug("Animation effects effect has changed. Resetting parameters.");
			animationEffect.Parameters = GenerateAnimationEffectParameterValues(effect).ToList();
		}

		animationEffect.Effect = effect;

		_store.UpdateAnimationEffect(animationEffect);

		return _repository.SaveChangesAsync(token);
	}


	/// <inheritdoc />
	public async Task RemoveAnimationEffectAsync(Animation animation, AnimationEffect animationEffect, CancellationToken token = default)
	{
		_logger.LogDebug("Remove animationEffect from animation.");

		// Saves the changes in the database.
		_store.RemoveAnimationEffect(animationEffect);
		await _repository.SaveChangesAsync(token);

		_logger.LogTrace("AnimationEffect has been removed from the animation.");
	}


	/// <inheritdoc />
	public Animation CopyAnimation(Animation animation, string newName)
	{
		_logger.LogDebug($"Creating copy of animation {animation.Name}.");
		Animation newAnimation = _animationFactory.CopyAnimation(animation);
		newAnimation.Name = newName;

		return newAnimation;
	}


	/// <inheritdoc />
	public Task UpdateAnimationEffectParameterValuesAsync(IEnumerable<AnimationEffectParameterValue> parameter, CancellationToken token = default)
	{
		_logger.LogDebug("Updating animation effect parameters.");
		_store.UpdateAnimationEffectParameterValues(parameter);

		return _repository.SaveChangesAsync(token);
	}
}