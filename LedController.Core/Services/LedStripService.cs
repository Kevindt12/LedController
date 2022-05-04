using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.CommunicationBuses;
using LedController.Core.Factories;
using LedController.Core.Ledstrips;
using LedController.Core.State;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Core.Services
{
	public class LedstripService : ILedstripService
	{
		private readonly ILogger<LedstripService> _logger;
		private readonly ApplicationState _applicationState;
		private readonly LedstripConnectionFactory _ledstripConnectionFactory;


		public LedstripService(ILogger<LedstripService> logger, ApplicationState applicationState, LedstripConnectionFactory ledstripConnectionFactory)
		{
			_logger = logger;
			_applicationState = applicationState;
			_ledstripConnectionFactory = ledstripConnectionFactory;
		}


		/// <summary>
		/// Checks if we have a led strip connection.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool LedstripConnectionExists(Ledstrip ledstrip)
		{
			return _applicationState.LedstripConnections.Any(x => x.Ledstrip == ledstrip);
		}


		/// <summary>
		/// Creates a led strip connection.
		/// </summary>
		/// <param name="ledStrip">The led strip we want to make a connection with.</param>
		/// <param name="connection">The connection.</param>
		/// <returns></returns>
		public ILedstripConnection CreateLedStripConnection(Ledstrip ledStrip, IBusConnection connection)
		{
			if (_applicationState.LedstripConnections.Any(x => x.Ledstrip == ledStrip))
			{
				throw new InvalidOperationException($"Cannot create a led strip connection that is already exists.");
			}

			// Creating a new led strip connection.
			ILedstripConnection ledstripConnection = _ledstripConnectionFactory.CreateLedStripConnection(ledStrip, connection);

			// Adding the connection to the application.
			_applicationState.LedstripConnections.Add(ledstripConnection);

			return ledstripConnection;
		}


		/// <summary>
		/// Gets the led strip connection by id.
		/// </summary>
		/// <param name="id">The id of the led strip connection.</param>
		/// <returns></returns>
		public ILedstripConnection GetLedstripConnectionById(Ledstrip ledstrip)
		{
			return _applicationState.LedstripConnections.Single(x => x.Ledstrip == ledstrip);
		}
	}
}
