using System;
using System.Linq;



namespace LedController.Domain.Models;

public sealed class EffectAssembly
{
	/// <summary>
	/// Id of the assembly file.
	/// </summary>
	public Guid Id { get; init; }


	/// <summary>
	/// The assembly file that we cna load or store in memory
	/// </summary>
	public EffectAssembly() { }


	/// <summary>
	/// Generates the file name for this effect.
	/// </summary>
	/// <returns> The file name of the effect. </returns>
	public string GenerateFileName()
	{
		return $"EffectAssembly-{Id}.dll";
	}


	private bool Equals(EffectAssembly other)
	{
		return Id.Equals(other.Id);
	}


	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		return ReferenceEquals(this, obj) || obj is EffectAssembly other && Equals(other);
	}


	/// <inheritdoc />
	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}


	public static bool operator ==(EffectAssembly left, EffectAssembly right)
	{
		return Equals(left, right);
	}


	public static bool operator !=(EffectAssembly left, EffectAssembly right)
	{
		return !Equals(left, right);
	}
}