using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Services;

/// <summary>
/// Service to handle anything to do with the ledstrip.
/// </summary>
public interface ILedstripService
{
    /// <summary>
    /// Tests ledstrip to see if its working.
    /// </summary>
    /// <param name="token"> A token to cancel the test. </param>
    /// <returns> </returns>
    Task TestLedstripAsync(Ledstrip ledstrip, CancellationToken token = default);
}