using System;
using System.Linq;



namespace LedController.Domain.Enums;

/// <summary>
/// The protocol that we use to communicate with the ledstrip.
/// </summary>
public enum LedstripProtocol
{
	/// <summary>
	/// Custom protocol.
	/// </summary>
	Custom = 0,

	/// <summary>
	/// The neopixel protocol.
	/// </summary>
	NeoPixel = 1
}