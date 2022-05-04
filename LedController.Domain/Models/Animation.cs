using System;
using System.Collections.Generic;
using System.Linq;



namespace LedController.Domain.Models;

public sealed class Animation : IEquatable<Animation>
{
	/// <summary>
	/// The id of the animation.
	/// </summary>
	public Guid Id { get; init; }


	/// <summary>
	/// The name of the animation.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// The effects that we want to play on the ledstrip based on this animation.
	/// </summary>
	public IList<AnimationEffect> Effects { get; set; }


	/// <summary>
	/// Creates a new effect.
	/// </summary>
	public Animation()
	{
		Effects = new List<AnimationEffect>();
	}


	/// <inheritdoc />
	public bool Equals(Animation other)
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

		return Equals((Animation)obj);
	}


	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}


	public static bool operator ==(Animation left, Animation right)
	{
		return Equals(left, right);
	}


	public static bool operator !=(Animation left, Animation right)
	{
		return !Equals(left, right);
	}
}