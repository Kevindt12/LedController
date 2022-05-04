using System;
using System.Linq;

using LedController.Domain.Enums;



namespace LedController.Domain.Models;

public record SpiBusSettings
{
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