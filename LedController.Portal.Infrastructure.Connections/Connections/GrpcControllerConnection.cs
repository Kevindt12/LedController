using System;
using System.Linq;

using AutoMapper;

using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

using Grpc.Core;
using Grpc.Net.Client;

using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Infrastructure.Connections.Protos;
using LedController.WebPortal.Infrastructure.Exceptions;

using Microsoft.Extensions.Logging;

using Animation = LedController.Domain.Models.Animation;
using EffectAssembly = LedController.Domain.Models.EffectAssembly;
using Ledstrip = LedController.Domain.Models.Ledstrip;



namespace LedController.WebPortal.Infrastructure.Connections.Connections;

internal sealed class GrpcControllerConnection : IControllerConnection
{
    private readonly ILogger<GrpcControllerConnection> _logger;
    private readonly IMapper _mapper;
    private readonly ILoggerFactory _loggerFactory;


    private readonly GrpcConnection.GrpcConnectionClient _connectionClient;
    private readonly GrpcChannel _channel;


    /// <summary>
    /// If the controller is connected.
    /// </summary>
    public bool IsConnected { get; private set; }

    /// <summary>
    /// The controller that we are connecting to.
    /// </summary>
    public Controller Controller { get; }


    public GrpcControllerConnection(ILogger<GrpcControllerConnection> logger,
                                    IMapper mapper,
                                    ILoggerFactory loggerFactory,
                                    Controller controller)
    {
        _logger = logger;
        _mapper = mapper;
        _loggerFactory = loggerFactory;

        Controller = controller;

        // Creating the client for the connection.
        _channel = CreateGrpcChannel(controller);
        _connectionClient = new GrpcConnection.GrpcConnectionClient(_channel);
    }


    /// <summary>
    /// Creates a new channel for the grpc connection.
    /// </summary>
    /// <param name="controller"> </param>
    /// <returns> </returns>
    private GrpcChannel CreateGrpcChannel(Controller controller)
    {
        UriBuilder builder = new UriBuilder();
        builder.Host = controller.EndPoint.Address.ToString();
        builder.Port = controller.EndPoint.Port;
        builder.Scheme = "http";

        return GrpcChannel.ForAddress(builder.Uri, new GrpcChannelOptions { LoggerFactory = _loggerFactory });
    }


    /// <inheritdoc />
    public async Task ConnectAsync()
    {
        try
        {
            _logger.LogTrace($"Creating connection with {Controller.Name}");

            await _connectionClient.ConnectAsync(new Empty());
            IsConnected = true;

            _logger.LogTrace("Controller connected!");
        }
        catch (RpcException e)
        {
            _logger.LogError(e, "Controller was unable to connect");

            throw new ControllerConnectionException($"Controller {Controller.Id} was unable to connect.", e, Controller);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a problem with the GRPC connection.");

            throw;
        }
    }


    /// <inheritdoc />
    public async Task PlayAsync(Ledstrip ledstrip, Animation animation, CancellationToken token = default)
    {
        _logger.LogTrace($"Sending message to {Controller.Id}, to play animation {animation.Id}.");

        ThrowIfUnconnected();

        ResultMessage result = await _connectionClient.PlayAnimationOnLedstripAsync(new PlayAnimationOnLedstripMessage
        {
            Ledstrip = _mapper.Map<Protos.Ledstrip>(ledstrip),
            Animation = _mapper.Map<Protos.Animation>(animation)
        });

        if (!result.Success)
        {
            _logger.LogError($"Failed playing animation {animation.Name} on ledstrip {ledstrip.Name} on controller {Controller.Name}. Error:  {result.ErrorMessage} ");

            ThrowControllerError(result.ErrorMessage, result.StackTrace);
        }

        _logger.LogTrace("Playing animation was successful");
    }


    /// <inheritdoc />
    public async Task StopAsync(Ledstrip ledstrip, CancellationToken token = default)
    {
        _logger.LogTrace($"Sending message to {Controller.Id}, to stop animation.");

        ThrowIfUnconnected();

        ResultMessage result = await _connectionClient.StopAnimationOnLedstripAsync(new LedstripInfo
                                                                                        { LedstripId = ledstrip.Id.ToString() });

        if (!result.Success)
        {
            _logger.LogError($"Failed to stop ledstrip {ledstrip.Name} on controller {Controller.Name}. Error:  {result.ErrorMessage} ");

            ThrowControllerError(result.ErrorMessage, result.StackTrace);
        }

        _logger.LogTrace("Stopping animation was successful");
    }


    /// <inheritdoc />
    public async Task TestAsync(Ledstrip ledstrip, CancellationToken token = default)
    {
        _logger.LogTrace($"Sending message to {Controller.Id}, test the strip.");

        ThrowIfUnconnected();

        ResultMessage result = await _connectionClient.TestLedstripAsync(_mapper.Map<Protos.Ledstrip>(ledstrip));

        if (!result.Success)
        {
            _logger.LogError($"Failed to test ledstrip {ledstrip.Name} on controller {Controller.Name}. Error:  {result.ErrorMessage} ");

            ThrowControllerError(result.ErrorMessage, result.StackTrace);
        }

        _logger.LogTrace("Test on ledstrip was successful");
    }


    /// <inheritdoc />
    public async Task UploadEffectAssemblyAsync(EffectAssembly assembly, ReadOnlyMemory<byte> file, CancellationToken token = default)
    {
        _logger.LogTrace($"Uploading effect assembly {assembly.Id}. MB {file.Length} is going to be send to the controller.");

        ThrowIfUnconnected();

        // TODO: Convert the assembly file ./
        ResultMessage result = await _connectionClient.UploadEffectAssemblyAsync(new Protos.EffectAssembly
                                                                                     { Id = assembly.Id.ToString(), Data = ByteString.CopyFrom(file.Span) });

        if (!result.Success)
        {
            _logger.LogError($"Failed to upload {assembly.Id} to controller {Controller.Name}. Error:  {result.ErrorMessage} ");

            ThrowControllerError(result.ErrorMessage, result.StackTrace);
        }

        _logger.LogTrace("Upload was successful successful");
    }


    /// <summary>
    /// Throw if connection is null.
    /// </summary>
    private void ThrowIfUnconnected()
    {
        if (_connectionClient == null) throw new ControllerConnectionException("The connection has not been established.", Controller);
    }


    private void ThrowControllerError(string errorMessage, string stackTrace)
    {
        throw new ControllerConnectionException($"There was a problem on controller {Controller.Id}, Error message: {errorMessage}. Stack Trace : {stackTrace}");
    }


    /// <inheritdoc />
    public void Dispose()
    {
        _channel?.Dispose();
    }


    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        _logger.LogTrace($"Creating connection with {Controller.Name}");

        try
        {
            await _connectionClient.DisconnectAsync(new Empty());
        }
        catch (RpcException e)
        {
            _logger.LogError($"There was a error with disconnecting from {Controller.Id}, while we where disposing of its connection.");

            // Not throwing we don't care if this was unsuccessful.
        }

        _channel?.Dispose();
    }
}