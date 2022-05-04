using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Models.Enums
{

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
}
