using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Models.Enums;



namespace LedController.Models.Models
{
	public class SpiBus
	{


		/// <summary>
		/// The if of the spi bus.
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// The name of the spi bus.
		/// </summary>
		public string Name { get; set; }


		/// <summary>
		/// The bus id of the spi bus.
		/// </summary>
		public int BusId { get; set; }

		/// <summary>
		/// The chip select id, indicating what selection we ware going to use.
		/// </summary>
		public int ChipSelectId { get; set; }


		/// <summary>
		/// The clock speed of the spi bus.
		/// </summary>
		public int ClockSpeed { get; set; }

		/// <summary>
		/// The size of the data byte.
		/// </summary>
		public int DataBitLength { get; set; }

		/// <summary>
		/// The flow of the data.
		/// </summary>
		public SpiBusDataFlow DataFlow { get; set; }

		/// <summary>
		/// The spi mode.
		/// </summary>
		public SpiMode Mode { get; set; }





	}
}
