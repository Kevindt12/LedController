using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

internal class LedstripManager : ManagerBase<Ledstrip, ILedstripStore>, ILedstripManager
{
    /// <summary>
    /// The manager that handles the information and manipulation of all the ledstrips.
    /// </summary>
    /// <param name="logger"> </param>
    /// <param name="repository"> </param>
    /// <param name="store"> </param>
    public LedstripManager(ILogger<Ledstrip> logger, IRepository repository, ILedstripStore store) : base(logger, repository, store) { }
}