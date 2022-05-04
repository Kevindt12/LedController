using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Domain.Models;


namespace LedController.Core.CommunicationBuses
{

	/// <summary>
	/// An SPI Bus connection.
	/// </summary>
	public interface ISpiBusConnection : IBusConnection
	{

		/// <summary>
		/// The Spi Bus.
		/// </summary>
		SpiBus SpiBus { get; }

	}
}
