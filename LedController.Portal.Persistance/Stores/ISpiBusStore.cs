using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The spi buses in the application.
/// </summary>
public interface ISpiBusStore : IStore<SpiBus>
{
	/// <summary>
	/// Adding a new spi bus.
	/// </summary>
	/// <param name="spiBus"> </param>
	/// <param name="controller"> </param>
	/// <returns> </returns>
	void AddSpiBus(SpiBus spiBus, Controller controller);
}