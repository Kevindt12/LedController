using System;
using System.Collections.Generic;
using System.Linq;

using UnitsNet;



namespace LedController.Domain.Models;

public class AnimationEffect : IEquatable<AnimationEffect>
{
	/// <summary>
	/// The id of the effect.
	/// </summary>
	public Guid Id { get; set; }


	/// <summary>
	/// THe effect of the effect.
	/// </summary>
	public Effect Effect { get; set; }

	/// <summary>
	/// The animation its attached to.
	/// </summary>
	public Animation Animation { get; set; }

	/// <summary>
	/// The frequency of the effect. If the effect is static this will throw a NotSupportedExceotion
	/// </summary>
	public Frequency Frequency { get; set; }


	/// <summary>
	/// The duration of this effect.
	/// </summary>
	public TimeSpan? Duration { get; set; }


	/// <summary>
	/// The parameters and values that are part of this animation effect
	/// </summary>
	public IList<AnimationEffectParameterValue> Parameters { get; set; }


	/// <summary>
	/// The effect attached to a animation.
	/// </summary>
	public AnimationEffect()
	{
		Parameters = new List<AnimationEffectParameterValue>();
	}


	public AnimationEffect(Effect effect,
						   Animation animation,
						   Frequency frequency,
						   TimeSpan? duration)
	{
		Effect = effect;
		Animation = animation;
		Frequency = frequency;
		Duration = duration;
	}


	/// <inheritdoc />
	public bool Equals(AnimationEffect other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}


	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;

		return Equals((AnimationEffect)obj);
	}


	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}


	public static bool operator ==(AnimationEffect left, AnimationEffect right)
	{
		return Equals(left, right);
	}


	public static bool operator !=(AnimationEffect left, AnimationEffect right)
	{
		return !Equals(left, right);
	}
}