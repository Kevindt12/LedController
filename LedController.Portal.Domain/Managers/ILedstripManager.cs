using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// The led strips that we want manager in the application.
/// </summary>
public interface ILedstripManager : IManager<Ledstrip> { }