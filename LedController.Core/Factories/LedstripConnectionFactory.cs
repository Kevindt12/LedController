using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.CommunicationBuses;
using LedController.Core.Ledstrips;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Core.Factories
{
	public class LedstripConnectionFactory
	{
		private readonly ILoggerFactory _loggerFactory;


		public LedstripConnectionFactory(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}


		public ILedstripConnection CreateLedStripConnection(Ledstrip ledstrip, IBusConnection connection)
		{
			return new Ws29LedStripConnection(_loggerFactory.CreateLogger<Ws29LedStripConnection>(), ledstrip, connection);
		}



	}
}
