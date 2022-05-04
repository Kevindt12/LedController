using System;
using System.Linq;



namespace LedController.Data.Entities
{
	public class AnimationEntity
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
		/// Is a static animation. Meaning that the animation only has one frame.
		/// </summary>
		public bool IsStatic { get; set; }

		/// <summary>
		/// The effects that we want to use.
		/// </summary>
		public string EffectsJson { get; set; }



	}
}
