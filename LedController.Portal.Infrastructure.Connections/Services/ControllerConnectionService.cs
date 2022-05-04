using System;
using System.Linq;

using Grpc.Core;

using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Infrastructure.Connections.Connections;
using LedController.WebPortal.Infrastructure.Connections.Factories;
using LedController.WebPortal.Infrastructure.Exceptions;
using LedController.WebPortal.Infrastructure.Services;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Infrastructure.Connections.Services;

internal class GrpcControllerConnectionService : IControllerConnectionService, IDisposable, IAsyncDisposable
{
    private readonly ILogger _logger;
    private readonly ControllerConnectionFactory _controllerConnectionFactory;

    /// <summary>
    /// The connections with the controllers.
    /// </summary>
    protected ICollection<IControllerConnection> Connections { get; init; }


    public GrpcControllerConnectionService(ILogger<GrpcControllerConnectionService> logger, ControllerConnectionFactory controllerConnectionFactory)
    {
        _logger = logger;
        _controllerConnectionFactory = controllerConnectionFactory;
        Connections = new List<IControllerConnection>();
    }


    /// <inheritdoc />
    public async Task<IControllerConnection> ConnectAsync(Controller controller, CancellationToken token = default)
    {
        _logger.LogTrace($"Start connection with {controller.Name}.");

        if (IsControllerConnected(controller))
        {
            return Connections.Single(c => c.Controller == controller);
        }

        GrpcControllerConnection connection = _controllerConnectionFactory.CreateGrpcConnection(controller);

        try
        {
            await connection.ConnectAsync();

            Connections.Add(connection);
            _logger.LogTrace($"Connection with {controller.Name} successful!");
        }
        catch (RpcException rpcException)
        {
            _logger.LogError(rpcException, $"Unable to connect to controller {controller.Name}");

            throw new ControllerConnectionException("There was a RPC error with the controller connection.", rpcException, controller);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"There was a problem with the connection of {controller.Name}.");

            throw;
        }

        return connection;
    }


    /// <inheritdoc />
    public IControllerConnection? GetControllerConnectionOrDefault(Controller controller)
    {
        _logger.LogTrace($"Getting controller connection with {controller.Name}.");

        return Connections.FirstOrDefault(x => x.Controller == controller);
    }


    /// <inheritdoc />
    public bool IsControllerConnected(Controller controller)
    {
        _logger.LogTrace($"Checking if controller {controller.Name} is connected.");

        return Connections.Any(x => x.Controller == controller);
    }


    /// <inheritdoc />
    public async Task DisconnectAsync(Controller controller, CancellationToken token = default)
    {
        _logger.LogTrace($"Disconnecting from controller {controller}.");
        IControllerConnection? connection;

        if ((connection = GetControllerConnectionOrDefault(controller)) == null)
        {
            _logger.LogWarning($"Trying to disconnect from controller {controller.Name}, yet not connected to controller.");

            return;
        }

        await connection.DisposeAsync();
        Connections.Remove(connection);
        _logger.LogTrace($"Disconnected from controller {controller.Name}.");
    }


    #region Disposable

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            while (Connections.Count > 0)
            {
                IControllerConnection connection = Connections.First();
                connection.Dispose();
                Connections.Remove(connection);
            }
        }
    }


    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(false);
        GC.SuppressFinalize(this);
    }


    protected async ValueTask DisposeAsyncCore()
    {
        while (Connections.Count > 0)
        {
            IControllerConnection connection = Connections.First();
            await connection.DisposeAsync();
            Connections.Remove(connection);
        }
    }

    #endregion
}