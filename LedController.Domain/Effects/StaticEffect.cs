using System;
using System.Linq;

using Microsoft.Extensions.Logging;



namespace LedController.Domain.Effects;

public abstract class StaticEffect : EffectBase
{
	/// <summary>
	/// The loop that is used to move to the next frame.
	/// </summary>
	public abstract void Set();


	/// <inheritdoc />
	protected StaticEffect(ILogger logger, int pixelCount, EffectParametersBase parameters) : base(logger, pixelCount, parameters) { }
}