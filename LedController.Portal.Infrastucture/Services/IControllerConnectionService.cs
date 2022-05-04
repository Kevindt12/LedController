using System;
using System.Linq;

using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Infrastructure.Connections;



namespace LedController.WebPortal.Infrastructure.Services;

/// <summary>
/// The service that handles the connections with the controller.
/// </summary>
public interface IControllerConnectionService
{
    /// <summary>
    /// Creates a connection with a controller.
    /// </summary>
    /// <param name="controller"> The controller we want to connect with. </param>
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    Task<IControllerConnection> ConnectAsync(Controller controller, CancellationToken token = default);


    /// <summary>
    /// Gets a connection with a controller. If there is a connection else it will send back a null.
    /// </summary>
    /// <param name="controller"> </param>
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    IControllerConnection? GetControllerConnectionOrDefault(Controller controller);


    /// <summary>
    /// Gets a flag indicating that we have a connection with a controller.
    /// </summary>
    /// <param name="controller"> </param>
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    bool IsControllerConnected(Controller controller);


    /// <summary>
    /// Disconnects from the controller.
    /// </summary>
    /// <param name="controller"> </param>
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    Task DisconnectAsync(Controller controller, CancellationToken token = default);
}