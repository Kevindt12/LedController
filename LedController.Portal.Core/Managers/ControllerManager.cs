using System;

using LedController.Shared.Extensions;

using System.Linq;
using System.Net.Sockets;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

internal class ControllerManager : ManagerBase<Controller, IControllerStore>, IControllerManager
{
    private readonly ILogger<ControllerManager> _logger;


    public ControllerManager(ILogger<ControllerManager> logger, IRepository repository, IControllerStore controllerStore) : base(logger, repository, controllerStore)
    {
        _logger = logger;
    }


    /// <inheritdoc />
    public override async Task Add(Controller item, CancellationToken token = default)
    {
        _logger.LogInformation("Adding new controller.");

        if (item.EndPoint.AddressFamily != AddressFamily.InterNetwork)
        {
            throw new InvalidOperationException("Cannot control a controller that is outside the local network.");
        }

        // Check if we have a IP Address that is already known to the portal.
        if ((await _store.GetAsync().AsEnumerableAsync(token)).Any(x => x.EndPoint.Address.Equals(item.EndPoint.Address)))
        {
            throw new InvalidOperationException("Cannot create a new controller with a already existing IP Address of a other controller.");
        }

        await base.Add(item, token);
    }


    /// <inheritdoc />
    public virtual Task<Controller> GetControllerBySpiBusAsync(SpiBus spiBus, CancellationToken token = default)
    {
        _logger.LogDebug($"Getting controller by spi bus {spiBus?.Name}");

        return _store.GetControllerBySpiBusAsync(spiBus, token);
    }
}