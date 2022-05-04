using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// The spi bus manager that manages all the entries of the application.
/// </summary>
public interface ISpiBusManager : IManager<SpiBus>
{
	/// <summary>
	/// Adding a new spi bus.
	/// </summary>
	/// <param name="spiBus"> The spi bus that we want to add. </param>
	/// <param name="controller"> The controller that was selected. </param>
	/// <param name="token"> A token to cancel the current operation. </param>
	/// <returns> </returns>
	Task AddAsync(SpiBus spiBus, Controller controller, CancellationToken token = default);


	/// <summary>
	/// Updates the spi bus.
	/// </summary>
	/// <param name="spiBus"> THe spi bus that we want to update. </param>
	/// <param name="controller"> THe controller that we want to be selected. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task UpdateAsync(SpiBus spiBus, Controller controller, CancellationToken token = default);
}