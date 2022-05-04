using System;
using System.Linq;

using LedController.Controller.Domain.Animations;
using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;



namespace LedController.Controller.Domain.Factories;

public interface IAnimationPlayerFactory
{
	/// <summary>
	/// Creates a animation player with the current effect that we pass true
	/// </summary>
	/// <param name="animation"> The animation that we want to play. </param>
	/// <param name="ledstrip"> The ledstrip that we </param>
	/// <param name="effects"> </param>
	/// <returns> </returns>
	IAnimationPlayer CreateAnimationPlayer(Animation animation, LedstripProxy ledstrip, IEnumerable<EffectProxy> effects);
}