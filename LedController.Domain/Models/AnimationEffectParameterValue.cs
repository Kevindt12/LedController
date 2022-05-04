using System;
using System.Linq;



namespace LedController.Domain.Models;

public class AnimationEffectParameterValue
{
	/// <summary>
	/// The id of the animation effect parameter value.
	/// </summary>
	public Guid Id { get; init; }


	/// <summary>
	/// Effect parameter id.
	/// </summary>
	public Guid EffectParameterId { get; set; }


	/// <summary>
	/// The name of the parameter.
	/// </summary>
	public string Name { get; set; }


	/// <summary>
	/// The value of the parameter wrapped in a object.
	/// </summary>
	public object? Value { get; set; }


	public AnimationEffectParameterValue(string name, Guid effectParameterId, object? value)
	{
		Name = name;
		EffectParameterId = effectParameterId;
		Value = value;
	}


	/// <summary>
	/// The animation effect parameter value. The value of a parameter that we have in the animation effect.
	/// </summary>
	public AnimationEffectParameterValue() { }
}