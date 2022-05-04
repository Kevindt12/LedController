using System;
using System.Linq;

using LedController.WebPortal.Persistence.Stores;



namespace LedController.WebPortal.Persistence.Services;

/// <summary>
/// The system repository.
/// </summary>
public interface IRepository : IUnitOfWork
{
    /// <summary>
    /// The animations in the application.
    /// </summary>
    IAnimationStore Animations { get; }

    /// <summary>
    /// The controllers in the application.
    /// </summary>
    IControllerStore Controllers { get; }

    /// <summary>
    /// THe effects in the application.
    /// </summary>
    IEffectStore Effects { get; }

    /// <summary>
    /// The ledstrips in the application.
    /// </summary>
    ILedstripStore Ledstrips { get; }

    /// <summary>
    /// THe spi buses in the application.
    /// </summary>
    ISpiBusStore SpiBuses { get; }
}