using System;
using System.Collections.Generic;
using System.Device.Spi;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iot.Device.Spi;
using Iot.Device.Ws28xx;

using LedController.Core.CommunicationBuses;
using LedController.Core.Converters;
using LedController.Domain.Models;
using Microsoft.Extensions.Logging;



namespace LedController.Core.Ledstrips
{
	public class Ws29LedStripConnection : ILedstripConnection
	{

	
		public string Id { get;  }

		public IBusConnection Connection { get; }


		public Ledstrip Ledstrip { get; }


		public Ws29LedStripConnection(ILogger<Ws29LedStripConnection> logger, Ledstrip ledstrip, IBusConnection connection)
		{
			Id = Guid.NewGuid().ToString();

			Connection = connection;
		}




		public void Write(ReadOnlySpan<Color> colors)
		{
			Connection.Write(NeoPixelConverter.Convert(colors));
		}


		public void Clear()
		{
			Color[] clearColor = Enumerable.Repeat(Color.Black, Ledstrip.PixelCount).ToArray();

			Write(clearColor);
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Connection?.Dispose();
		}


	}
}
