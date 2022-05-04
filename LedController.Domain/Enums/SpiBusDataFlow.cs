using System;
using System.Linq;



namespace LedController.Domain.Enums;

/// <summary>
/// Specifies order in which bits are transferred first on the SPI bus.
/// </summary>
public enum SpiBusDataFlow
{
	/// <summary>
	/// Most significant bit will be sent first (most of the devices use this value).
	/// </summary>
	MsbFirst = 0,

	/// <summary>
	/// Least significant bit will be sent first.
	/// </summary>
	LsbFirst = 1
}