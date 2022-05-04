using System;
using System.Drawing;
using System.Linq;

using LedController.Domain.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Diagnostics;



namespace LedController.Domain.Effects;

public abstract class EffectBase
{
	protected readonly ILogger _logger;

	/// <summary>
	/// The effect parametersBase of the effect.
	/// </summary>
	public dynamic EffectParameters { get; set; }


	/// <summary>
	/// The base class used for the effects. This will also hold some basic functions that we can use for making effects.
	/// </summary>
	/// <param name="logger"> The logger that we can use. </param>
	/// <param name="pixelCount"> The pixel count. </param>
	/// <param name="parameters"> THe parameters for the effects. </param>
	protected EffectBase(ILogger logger, int pixelCount, EffectParametersBase parameters)
	{
		Guard.IsNotNull(parameters, nameof(parameters));

		PixelCount = pixelCount;
		_logger = logger;

		// Setting the current array to a empty array but not null.
		Pixels = new Color[pixelCount].Select(x => x = Color.Black).ToArray();

		EffectParameters = parameters;
	}


	/// <summary>
	/// The amount of pixels that we have in the led strip.
	/// </summary>
	public int PixelCount { get; }


	/// <summary>
	/// The current frame that we want to display.
	/// </summary>
	public Color[] Pixels { get; }


	/// <summary>
	/// The setup code used for this effect.
	/// </summary>
	public abstract void Setup();


	/// <summary>
	/// Clears the color array.
	/// </summary>
	private void Clear()
	{
		for (int i = 0; i < Pixels.Length; i++)
		{
			Pixels[i] = Color.Black;
		}
	}


	/// <summary>
	/// Gets the class name of the animation effect that was generated.
	/// </summary>
	/// <param name="effect"> </param>
	/// <returns> </returns>
	public static string GetEffectClassName(Effect effect)
	{
		return $"Generated{effect.Id:N}";
	}
}