using System;
using System.Device.Spi;
using System.Linq;
using System.Threading.Tasks;

using LedController.Domain.Models;



namespace LedController.Core.CommunicationBuses
{

	public class SpiBusConnection : ISpiBusConnection, IDisposable
	{
		private readonly SpiDevice _spiDevice;


		/// <summary>
		/// The Spi Bus.
		/// </summary>
		public SpiBus SpiBus { get; init; }


		/// <summary>
		/// A spi bus connection.
		/// </summary>
		/// <param name="spiBus"> The spi bus we want to connect to. </param>
		public SpiBusConnection(SpiBus spiBus)
		{
			SpiBus = spiBus;

			_spiDevice = SpiDevice.Create(new SpiConnectionSettings(spiBus.BusId, spiBus.ChipSelectId)
			{
				ClockFrequency = spiBus.ClockSpeed,
				DataBitLength = spiBus.DataBitLength,
				DataFlow = (DataFlow)spiBus.DataFlow,
				Mode = (SpiMode)spiBus.Mode
			});
		}


		/// <summary>
		/// Writes buffer to a bus.
		/// </summary>
		/// <param name="buffer"> The buffer we want to send. </param>
		/// <returns> </returns>
		public Task WriteAsync(ReadOnlySpan<byte> buffer)
		{
			_spiDevice.Write(buffer);

			return Task.CompletedTask;
		}


		/// <summary>
		/// Writes buffer to a bus.
		/// </summary>
		/// <param name="buffer"> The buffer we want to send. </param>
		public void Write(ReadOnlySpan<byte> buffer)
		{
			_spiDevice.Write(buffer);
		}


		public void Dispose()
		{
			_spiDevice?.Dispose();
		}
	}

}