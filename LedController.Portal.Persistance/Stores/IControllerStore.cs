using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The controller store.
/// </summary>
public interface IControllerStore : IStore<Controller>
{
	/// <summary>
	/// Removes this effect from all synced controllers indicating to the controllers that we need to rsync it.
	/// </summary>
	/// <param name="effect"> The effect that we want to decouple from. </param>
	void RemoveSyncedEffect(Effect effect);


	/// <summary>
	/// Gets a controller by spi bus.
	/// </summary>
	/// <param name="spiBus"> The spi bus that we want to use to get its parent controller. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task<Controller> GetControllerBySpiBusAsync(SpiBus spiBus, CancellationToken token = default);
}