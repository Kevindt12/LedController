using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// The manager that manages all the controllers in the application.
/// </summary>
public interface IControllerManager : IManager<Controller>
{
	/// <summary>
	/// Gets a controller by a spi bus.
	/// </summary>
	/// <param name="spiBus"> The spi bus that we want to parent controller from. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task<Controller> GetControllerBySpiBusAsync(SpiBus spiBus, CancellationToken token = default);
}