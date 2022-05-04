using System;

using LedController.Shared.Extensions;

using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Domain.Services;
using LedController.WebPortal.Infrastructure.Connections;
using LedController.WebPortal.Infrastructure.Services;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Services;

internal class ControllerService : IControllerService
{
    private readonly ILogger<ControllerService> _logger;
    private readonly IControllerManager _controllerManager;
    private readonly IControllerConnectionService _controllerConnectionService;
    private readonly IFileService _fileService;


    protected virtual IDictionary<Ledstrip, Animation> PlayingAnimations { get; }


    /// <summary>
    /// The connections service that handles all the items that have to do with the controllers.
    /// </summary>
    /// <param name="logger"> </param>
    /// <param name="controllerConnectionCollection"> </param>
    public ControllerService(ILogger<ControllerService> logger,
                             IControllerManager controllerManager,
                             IControllerConnectionService controllerConnectionService,
                             IAnimationManager animationManager,
                             IEffectManager effectManager,
                             IFileService fileService)
    {
        _logger = logger;
        _controllerManager = controllerManager;
        _controllerConnectionService = controllerConnectionService;
        _fileService = fileService;

        PlayingAnimations = new Dictionary<Ledstrip, Animation>();
    }


    /// <inheritdoc />
    public bool IsControllerConnected(Controller controller)
    {
        _logger.LogTrace($"Checking if controller {controller.Name} is connected.");

        return _controllerConnectionService.IsControllerConnected(controller);
    }


    /// <inheritdoc />
    public Animation? GetPlayingAnimationOnLedstripOrDefault(Ledstrip ledstrip)
    {
        _logger.LogTrace($"Getting if there is an animation playing on ledstrip {ledstrip.Name}.");

        if (PlayingAnimations.Any(x => x.Key == ledstrip))
        {
            _logger.LogTrace($"Animation {PlayingAnimations[ledstrip].Name} is playing on the ledstrip.");

            return PlayingAnimations[ledstrip];
        }

        return null;
    }


    /// <inheritdoc />
    public async Task ConnectToControllerAsync(Controller controller, CancellationToken token = default)
    {
        _logger.LogDebug($"Connecting to controller {controller.Id}.");

        // Checking if the controller is already connected.
        if (IsControllerConnected(controller))
        {
            _logger.LogDebug("The connection with the controller already exists therefore not creating a connection again.");

            return;
        }

        // Try to create a connection.
        await _controllerConnectionService.ConnectAsync(controller, token);
        _logger.LogDebug("The controller has been connected.");
    }


    /// <inheritdoc />
    public async Task SynchronizeEffect(Controller controller, Effect effect, CancellationToken token = default)
    {
        _logger.LogInformation($"Start Syncing effect {effect.Name} with controller {controller.Name}.");

        // Gets the controller connection that we need to upload a effect to the controller.
        IControllerConnection connection = _controllerConnectionService.GetControllerConnectionOrDefault(controller) ??
                                           throw new InvalidOperationException("We cannot sync a effect with a controller that is not connected.");

        // Check if there is a file first.
        _logger.LogTrace("Checking if we have a assembly that exists");
        _fileService.FileExists(effect.EffectAssembly?.GenerateFileName()!);

        _logger.LogTrace("Loading assembly file into memeory.");
        ReadOnlyMemory<byte> assemblyFile = await _fileService.OpenAssemblyAsync(effect.EffectAssembly!, token);

        _logger.LogTrace("Sending the effect assembly to controller.");
        await connection.UploadEffectAssemblyAsync(effect.EffectAssembly!, assemblyFile, token);
        _logger.LogInformation("The effect has been uploaded to the device.");
    }


    /// <inheritdoc />
    public async Task PlayAnimationOnLedstrip(Ledstrip ledstrip, Animation animation, CancellationToken token = default)
    {
        Controller controller = (await _controllerManager.GetAsync().AsEnumerableAsync(token)).SingleOrDefault(x => x.Ledstrips.Any(x => x == ledstrip)) ??
                                throw new InvalidOperationException("There was no controller attached to this ledstrip.");

        // Gets the controller connection that we need to upload a effect to the controller.
        IControllerConnection connection = _controllerConnectionService.GetControllerConnectionOrDefault(controller) ??
                                           throw new InvalidOperationException("We cannot sync a effect with a controller that is not connected.");

        await connection.PlayAsync(ledstrip, animation, token);

        // Settings the context for the connection so we know what is happening on the controllers.
        PlayingAnimations.Add(ledstrip, animation);
    }


    /// <inheritdoc />
    public async Task StopAnimationOnLedstrip(Ledstrip ledstrip, CancellationToken token = default)
    {
        Controller controller = (await _controllerManager.GetAsync().AsEnumerableAsync(token)).SingleOrDefault(x => x.Ledstrips.Any(x => x == ledstrip)) ??
                                throw new InvalidOperationException("There was no controller attached to this ledstrip.");

        // Gets the controller connection that we need to upload a effect to the controller.
        IControllerConnection connection = _controllerConnectionService.GetControllerConnectionOrDefault(controller) ??
                                           throw new InvalidOperationException("We cannot sync a effect with a controller that is not connected.");

        await connection.StopAsync(ledstrip, token);

        // Removes the entry that we are not playing anymore.
        PlayingAnimations.Remove(ledstrip);
    }


    /// <inheritdoc />
    public async Task TestLedstripAsync(Ledstrip ledstrip, CancellationToken token = default)
    {
        Controller controller = (await _controllerManager.GetAsync().AsEnumerableAsync(token)).SingleOrDefault(x => x.Ledstrips.Any(x => x == ledstrip)) ??
                                throw new InvalidOperationException("There was no controller attached to this ledstrip.");

        // Gets the controller connection that we need to upload a effect to the controller.
        IControllerConnection connection = _controllerConnectionService.GetControllerConnectionOrDefault(controller) ??
                                           throw new InvalidOperationException("We cannot sync a effect with a controller that is not connected.");

        await connection.TestAsync(ledstrip, token);
    }


    /// <inheritdoc />
    public Task DisconnectAsync(Controller controller, CancellationToken token = default)
    {
        return _controllerConnectionService.DisconnectAsync(controller, token);
    }
}