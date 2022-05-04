using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.Animations;
using LedController.Core.Ledstrips;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;

using Animation = LedController.Core.Animations.Animation;



namespace LedController.Core.Factories
{
	public class AnimationPlayerFactory
	{
		private readonly ILoggerFactory _loggerFactory;


		public AnimationPlayerFactory(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}


		public virtual AnimationPlayer CreateAnimationPlayer(Animation animation,  ILedstripConnection connection)
		{
			AnimationPlayer player = new AnimationPlayer(_loggerFactory.CreateLogger<AnimationPlayer>(), animation, connection);

			return player;
		}



	}
}
