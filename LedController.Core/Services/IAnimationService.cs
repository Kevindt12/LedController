using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.Animations;
using LedController.Core.Effects;
using LedController.Core.Ledstrips;
using LedController.Domain.Models;

using Animation = LedController.Core.Animations.Animation;



namespace LedController.Core.Services
{
	public interface IAnimationService
	{

		/// <summary>
		/// Creates a animation player.
		/// </summary>
		/// <param name="animation">The animation we want to play.</param>
		/// <returns></returns>
		AnimationPlayer CreateAnimationPlayer(Animation animation, ILedstripConnection connection);


		/// <summary>
		/// Checks if there is a animation player available for the given led strip.
		/// </summary>
		/// <param name="ledstrip"></param>
		/// <returns></returns>
		bool DoesAnimationPlayerExist(Ledstrip ledstrip);


		AnimationPlayer GetAnimationPlayerByLedstrip(Ledstrip ledstrip);

	}
}
