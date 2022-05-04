using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Domain.Models;



namespace LedController.Core.Ledstrips
{
	public interface ILedstripConnection : IDisposable
	{


		Ledstrip Ledstrip { get;  }



		void Write(ReadOnlySpan<Color> colors);

		void Clear();


	}
}
