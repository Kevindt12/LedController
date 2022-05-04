using System;
using System.Linq;



namespace LedController.Domain.Models;

public class EffectFile : IEquatable<EffectFile>
{
	/// <summary>
	/// The id of the effect file.
	/// </summary>
	public Guid Id { get; init; }


	/// <summary>
	/// The content of the effect file. The C# code that can be compiled.
	/// </summary>
	public string Content { get; set; }


	/// <summary>
	/// The effect code file.
	/// </summary>
	public EffectFile() { }


	/// <inheritdoc />
	public bool Equals(EffectFile other)
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

		return Equals((EffectFile)obj);
	}


	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}


	public static bool operator ==(EffectFile left, EffectFile right)
	{
		return Equals(left, right);
	}


	public static bool operator !=(EffectFile left, EffectFile right)
	{
		return !Equals(left, right);
	}
}