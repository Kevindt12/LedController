using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Communication.Messages
{

	/// <summary>
	/// The header of all messages that we send.
	/// </summary>
	public class MessageHeader
	{

		/// <summary>
		/// THe id of the message that we are sending or receiving.
		/// </summary>
		public int MessageId { get; set; }

		


	}
}
