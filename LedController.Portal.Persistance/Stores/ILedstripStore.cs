using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The ledstrips in the application.
/// </summary>
public interface ILedstripStore : IStore<Ledstrip> { }