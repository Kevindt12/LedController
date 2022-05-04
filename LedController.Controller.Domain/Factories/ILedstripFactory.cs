using System;
using System.Linq;

using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;



namespace LedController.Controller.Domain.Factories;

/// <summary>
/// The factory used to create ledstrip proxies.
/// </summary>
public interface ILedstripFactory
{
    /// <summary>
    /// Creates a proxy ledstrip that can be used to interact with the system.
    /// </summary>
    /// <param name="ledstrip"> The ledstrip that we want the implementation for. </param>
    /// <returns> </returns>
    LedstripProxy CreateLedstripProxy(Ledstrip ledstrip);
}