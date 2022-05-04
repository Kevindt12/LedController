using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.CommunicationBuses;
using LedController.Core.Ledstrips;
using LedController.Domain.Models;


namespace LedController.Core.Services
{
	public interface ILedstripService
	{

		/// <summary>
		/// Checks if we have a led strip connection.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool LedstripConnectionExists(Ledstrip ledstrip);

		/// <summary>
		/// Creates a led strip connection.
		/// </summary>
		/// <param name="ledStrip">The led strip we want to make a connection with.</param>
		/// <param name="connection">The connection.</param>
		/// <returns></returns>
		ILedstripConnection CreateLedStripConnection(Ledstrip ledStrip, IBusConnection connection);


		/// <summary>
		/// Gets the led strip connection by id.
		/// </summary>
		/// <param name="id">The id of the led strip connection.</param>
		/// <returns></returns>
		ILedstripConnection GetLedstripConnectionById(Ledstrip ledstrip);


	}
}
