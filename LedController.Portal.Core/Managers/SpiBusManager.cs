using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

internal class SpiBusManager : ManagerBase<SpiBus, ISpiBusStore>, ISpiBusManager
{
	private readonly ILogger<SpiBusManager> _logger;


	public SpiBusManager(ILogger<SpiBusManager> logger, IRepository repository, ISpiBusStore store) : base(logger, repository, store)
	{
		_logger = logger;
	}


	/// <inheritdoc />
	public virtual async Task AddAsync(SpiBus spiBus, Controller controller, CancellationToken token = default)
	{
		_logger.LogDebug($"Adding new spi bus {spiBus.Name}, with controller {controller}. ");
		_repository.SpiBuses.AddSpiBus(spiBus, controller);

		// Saving changes to the database.
		await _repository.SaveChangesAsync(token);
		_logger.LogDebug("Spi bus has been added.");
	}


	/// <inheritdoc />
	public virtual async Task UpdateAsync(SpiBus spiBus, Controller controller, CancellationToken token = default)
	{
		// Updating. the spi bus.
		_logger.LogDebug($"Updating spi bus {spiBus.Name}, with controller {controller}. ");
		_repository.SpiBuses.Update(spiBus);
		await _repository.SaveChangesAsync(token);

		// Getting the original controller by the spi bus.
		_logger.LogTrace("Getting original controller to check if the controllers are the same or needs to be updated.");
		Controller originalController = await _repository.Controllers.GetControllerBySpiBusAsync(spiBus, token);

		// Checking if the controllers are the same if so then leave no need to update.
		if (originalController == controller) return;

		// Upading the controller removing the spi bus from the original.
		_logger.LogTrace($"Controller changed, updating {spiBus.Name} to controller {controller.Name}.");
		originalController.SpiBuses.Remove(spiBus);
		_repository.Controllers.Update(originalController);

		// Upading the current controller.
		_logger.LogTrace("Updating the controller.");
		controller.SpiBuses.Add(spiBus);
		_repository.Controllers.Update(controller);

		// Saving the data ot persistance.
		await _repository.SaveChangesAsync(token);
		_logger.LogDebug("Done updating the spi bus.");
	}


	/// <inheritdoc />
	public override async Task Remove(SpiBus item, CancellationToken token = default)
	{
		// Getting controller.
		_logger.LogDebug($"Removing spi bus {item.Id}.");
		Controller controller = await _repository.Controllers.GetControllerBySpiBusAsync(item, token);

		// Changing the persistance data.
		controller.SpiBuses.Remove(item);
		_repository.SpiBuses.Remove(item);
		_repository.Controllers.Update(controller);

		// Save changes to database.
		await _repository.SaveChangesAsync(token);
		_logger.LogDebug("Spi bus has been deleted.");
	}
}