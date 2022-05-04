using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Core.CommunicationBuses
{

	/// <summary>
	/// The bus connection we can connect to send data to.
	/// </summary>
	public interface IBusConnection : IDisposable
	{
		/// <summary>
		/// Writes buffer to a bus.
		/// </summary>
		/// <param name="buffer">The buffer we want to send.</param>
		/// <returns></returns>
		Task WriteAsync(ReadOnlySpan<byte> buffer);

		/// <summary>
		/// Writes buffer to a bus.
		/// </summary>
		/// <param name="buffer">The buffer we want to send.</param>
		void Write(ReadOnlySpan<byte> buffer);


	}
}
