using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.Effects;



namespace LedController.Core.Animations
{

	public class Animation
	{

		/// <summary>
		/// The id of the animation.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The name of the animation.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The effects that we want to play on this animation.
		/// </summary>
		public ICollection<Effect> Effects { get; set; }

		/// <summary>
		/// The playback speed of the animation.
		/// </summary>
		public int Frequency { get; set; }

		/// <summary>
		/// If the animation should keep looping or is a static entity, this means that it will only display the first effect and not move the effect to the next stage.
		/// </summary>
		public bool IsStatic { get; set; }


		/// <summary>
		/// The animation we want to play.
		/// </summary>
		public Animation()
		{
			Effects = new List<Effect>();
		}




	}
}
