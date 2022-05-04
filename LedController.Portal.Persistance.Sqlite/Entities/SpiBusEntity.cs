using System;
using System.Linq;

using LedController.Domain.Enums;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

public class SpiBusEntity : EntityBase
{
	/// <summary>
	/// The name of the spi bus.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	/// The bus id of the spi bus.
	/// </summary>
	public int BusId { get; set; }

	/// <summary>
	/// The chip select id, indicating what selection we ware going to use.
	/// </summary>
	public int ChipSelectId { get; set; }

	/// <summary>
	/// Uses custom settings for the ledstrip. Else it will use it from the led strip
	/// </summary>
	public bool UseCustomSettings { get; set; }

	/// <summary>
	/// The clock speed of the spi bus.
	/// </summary>
	public int ClockSpeed { get; set; }

	/// <summary>
	/// The size of the data byte.
	/// </summary>
	public int DataBitLength { get; set; }

	/// <summary>
	/// The flow of the data.
	/// </summary>
	public SpiBusDataFlow DataFlow { get; set; }

	/// <summary>
	/// The spi mode.
	/// </summary>
	public SpiMode Mode { get; set; }
}