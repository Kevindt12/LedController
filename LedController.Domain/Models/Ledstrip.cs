using System;
using System.Collections.Generic;
using System.Linq;

using LedController.Domain.Enums;



namespace LedController.Domain.Models;

public class Ledstrip : IEquatable<Ledstrip>
{
	/// <summary>
	/// The id of the led strip.
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// The name of the led strip.
	/// </summary>
	public string Name { get; set; }


	/// <summary>
	/// The Pixel count of the led strip. Or the amount of leds that are the strip
	/// </summary>
	public int PixelCount { get; set; }


	/// <summary>
	/// The spi bus that we are connected to.
	/// </summary>
	public SpiBus? SpiBus { get; set; }

	/// <summary>
	/// The spi bus settings that we save on the ledstrip
	/// </summary>
	public SpiBusSettings? SpiBusSettings { get; set; }


	/// <summary>
	/// The protocol that we use to communicate with the ledstrip.
	/// </summary>
	public LedstripProtocol Protocol { get; set; }


	/// <summary>
	/// The ledstrip on the application.
	/// </summary>
	public Ledstrip() { }


	/// <summary> Serves as the default hash function. </summary>
	/// <returns> A hash code for the current object. </returns>
	public override int GetHashCode()
	{
		return Id != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Id) : 0;
	}


	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != GetType()) return false;

		return Equals((Ledstrip)obj);
	}


	public bool Equals(Ledstrip other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}


	public static bool operator ==(Ledstrip left, Ledstrip right)
	{
		return EqualityComparer<Ledstrip>.Default.Equals(left, right);
	}


	public static bool operator !=(Ledstrip left, Ledstrip right)
	{
		return !(left == right);
	}
}