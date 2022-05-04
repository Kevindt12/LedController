using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Core.Effects
{

	public class StaticEffect : Effect
	{
		public const string ColorParameterName = "Color";


		private Color _color;

		public override EffectType Type => EffectType.StaticColor;


		public Color Color
		{
			get => _color;
			set
			{
				_color = value; 
				Parameters.WriteParameter(ColorParameterName, value);
			}
		}


		public StaticEffect() : base()
		{

		}

		public StaticEffect(EffectParameters parameters) : base(parameters)
		{
			_color = ((StaticEffectParameters)parameters).Color;
		}


		/// <summary>
		/// Moves the effect to the next array. False if its at the end of the array.
		/// </summary>
		/// <returns></returns>
		public override bool MoveNext()
		{
			for (int i = 0; i < PixelCount; i++)
			{
				Current[i] = _color;
			}

			return true;
		}
	}



	public class StaticEffectParameters : EffectParameters
	{
		public Color Color { get; set; }
	}
}
