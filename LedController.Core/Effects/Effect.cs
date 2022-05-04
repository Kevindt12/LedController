using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Core.Effects
{

	public abstract class Effect
	{

		public String Id { get; set; }

		public abstract EffectType Type { get;}


		/// <summary>
		/// Our parameters dictionary where we save all the parameters.
		/// </summary>
		public EffectParameters Parameters { get; protected set; }


		/// <summary>
		/// The amount of colors we need ot display.
		/// </summary>
		public virtual int PixelCount { get; set; }


		/// <summary>
		/// The current color set we want to display.
		/// </summary>
		public virtual Color[] Current { get; protected set; }


		// For json use only.
		public Effect()
		{
			Id = Guid.NewGuid().ToString();
			Parameters = new EffectParameters();
		}


		public Effect(EffectParameters parameters)
		{
			Parameters = parameters;

			Current = new Color[PixelCount];
		}


		/// <summary>
		/// Moves the effect to the next array. False if its at the end of the array.
		/// </summary>
		/// <returns></returns>
		public abstract bool MoveNext();




	}
}
