using System;
using System.Linq;

using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;



namespace LedController.Controller.Domain.Factories;

/// <summary>
/// Creates the base effect that can be used in a animation player.
/// </summary>
public interface IEffectFactory
{
	/// <summary>
	/// Creates the effect base that can be used on the animation player.
	/// </summary>
	/// <returns> </returns>
	ValueTask<EffectProxy> CreateEffectProxyAsync(AnimationEffect animationEffect, int pixelCount , CancellationToken token = default);
}