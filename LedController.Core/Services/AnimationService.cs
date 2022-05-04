using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.Animations;
using LedController.Core.Effects;
using LedController.Core.Factories;
using LedController.Core.Ledstrips;
using LedController.Core.State;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;

using Animation = LedController.Core.Animations.Animation;



namespace LedController.Core.Services
{
	public class AnimationService : IAnimationService
	{
		private readonly ILogger<AnimationService> _logger;
		private readonly ApplicationState _applicationState;
		private readonly AnimationPlayerFactory _animationPlayerFactory;


		public AnimationService(ILogger<AnimationService> logger, ApplicationState applicationState, AnimationPlayerFactory animationPlayerFactory)
		{
			_logger = logger;
			_applicationState = applicationState;
			_animationPlayerFactory = animationPlayerFactory;
		}




		/// <summary>
		/// Creates a animation player.
		/// </summary>
		/// <param name="animation">The animation we want to play.</param>
		/// <returns></returns>
		public AnimationPlayer CreateAnimationPlayer(Animation animation, ILedstripConnection connection)
		{
			_logger.LogInformation($"Creating a animation player for {animation.Name} with led strip {connection.Ledstrip.Name}.");

			// Checks if we have any animation players running with the selected led strip.
			if (_applicationState.AnimationPlayers.Any(x => x.LedStrip == connection.Ledstrip))
			{
				_logger.LogError($"Trying to create a animation player for a led strip that already has an animation player.");

				throw new InvalidOperationException($"Cannot start a animation player when there is one active for that led strip.");
			}

			AnimationPlayer player = _animationPlayerFactory.CreateAnimationPlayer(animation, connection);

			// Adding the animation player to the application state.
			_applicationState.AnimationPlayers.Add(player);

			return player;
		}


		/// <summary>
		/// Checks if there is a animation player available for the given led strip.
		/// </summary>
		/// <param name="ledstrip"></param>
		/// <returns></returns>
		public bool DoesAnimationPlayerExist(Ledstrip ledstrip)
		{
			return _applicationState.AnimationPlayers.Any(x => x.LedStrip == ledstrip);
		}


		public AnimationPlayer GetAnimationPlayerByLedstrip(Ledstrip ledstrip)
		{
			return _applicationState.AnimationPlayers.Single(x => x.LedStrip == ledstrip);



		}
	}
}
