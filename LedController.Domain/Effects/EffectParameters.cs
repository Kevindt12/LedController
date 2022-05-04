using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Domain.Effects;

public class EffectParametersBase
{
    /// <summary>
    /// The parameters base object used to hold al the properties of
    /// </summary>
    public EffectParametersBase() { }


	/// <summary>
	/// Gets the generated class name of the effect parameters.
	/// </summary>
	/// <param name="effect"> The effect that we want to get the parameters class from. </param>
	/// <returns> </returns>
	public static string GetEffectClassName(Effect effect)
    {
        return $"GeneratedParameters{effect.Id:N}";
    }
}