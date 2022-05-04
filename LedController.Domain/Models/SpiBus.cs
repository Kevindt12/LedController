using System;
using System.Collections.Generic;
using System.Linq;



namespace LedController.Domain.Models;

public class SpiBus : IEquatable<SpiBus>
{
	/// <summary>
	/// The if of the spi bus.
	/// </summary>
	public Guid Id { get; init; }

	/// <summary>
	/// The name of the spi bus.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// The bus id of the spi bus.
	/// </summary>
	public int BusId { get; set; }

	/// <summary>
	/// The chip select id, indicating what selection we ware going to use.
	/// </summary>
	public int ChipSelectId { get; set; }


	/// <summary>
	/// The spi bus settings used for communication.
	/// </summary>
	public SpiBusSettings? Settings { get; set; }


	/// <summary>
	/// The ledstrip that we have connected to the bus.
	/// </summary>
	public Ledstrip? Ledstrip { get; set; }


	/// <summary>
	/// The spi bus that we ware using to connect to the led strip.
	/// </summary>
	public SpiBus()
	{
		Settings = new SpiBusSettings();
	}


	/// <summary> Serves as the default hash function. </summary>
	/// <returns> A hash code for the current object. </returns>
	public override int GetHashCode()
	{
		return Id != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Id) : 0;
	}


	public override bool Equals(object obj)
	{
		return Equals(obj as SpiBus);
	}


	public bool Equals(SpiBus other)
	{
		return other != null &&
			   Id == other.Id;
	}


	public static bool operator ==(SpiBus left, SpiBus right)
	{
		return EqualityComparer<SpiBus>.Default.Equals(left, right);
	}


	public static bool operator !=(SpiBus left, SpiBus right)
	{
		return !(left == right);
	}
}