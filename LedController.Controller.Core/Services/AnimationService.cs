using System;
using System.Linq;
using System.Text.Json;

using LedController.Controller.Domain.Animations;
using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Proxies;
using LedController.Controller.Domain.Services;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Core.Services;

internal class AnimationService : IAnimationService
{
    private readonly ILogger<AnimationService> _logger;
    private readonly IAnimationPlayerFactory _animationPlayerFactory;
    private readonly ILedstripFactory _ledstripFactory;
    private readonly IEffectFactory _effectFactory;

    /// <summary>
    /// The animation players that we have created.
    /// </summary>
    protected ICollection<IAnimationPlayer> Players { get; set; }


    /// <summary>
    /// The service that handles everything to do
    /// </summary>
    public AnimationService(ILogger<AnimationService> logger,
                            IAnimationPlayerFactory animationPlayerFactory,
                            ILedstripFactory ledstripFactory,
                            IEffectFactory effectFactory)
    {
        _logger = logger;
        _animationPlayerFactory = animationPlayerFactory;
        _ledstripFactory = ledstripFactory;
        _effectFactory = effectFactory;

        Players = new List<IAnimationPlayer>();
    }


    /// <inheritdoc />
    public IDictionary<Ledstrip, Animation> GetPlayingAnimations()
    {
        _logger.LogTrace("Getting all the animations playing on ledstrips.");

        return Players.ToDictionary(x => x.Ledstrip.Ledstrip, x => x.Animation);
    }


    /// <inheritdoc />
    public bool IsAnimationPlayingOnLedstrip(Guid ledstripId)
    {
        return Players.Any(x => x.Ledstrip.Ledstrip.Id == ledstripId);
    }


    /// <inheritdoc />
    public async Task StartAnimationAsync(Ledstrip ledstrip, Animation animation, CancellationToken token = default)
    {
        _logger.LogTrace($"Starting animation Ledstrip: {JsonSerializer.Serialize(ledstrip)} Animation {JsonSerializer.Serialize(animation)} ");

        // Creating the proxies.
        LedstripProxy ledstripProxy = _ledstripFactory.CreateLedstripProxy(ledstrip);
        IEnumerable<EffectProxy> effects = await CreateEffectProxies(animation, ledstrip.PixelCount, token);
        _logger.LogDebug("Created the proxies for both the animation and ledstrip.");

        // Creating and adding the player to list.
        _logger.LogDebug($"Creating animation player for ledstrip {ledstrip.Id}.");
        IAnimationPlayer player = _animationPlayerFactory.CreateAnimationPlayer(animation, ledstripProxy, effects);
        Players.Add(player);

        try
        {
            // Start player.
            _logger.LogTrace("Animation player has been created start playing animation.");
            await player.StartAsync();

            _logger.LogDebug("Animation has started.");
        }
        catch (AnimationException animationException)
        {
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a error with starting the animation player.");

            throw;
        }
    }


    /// <summary>
    /// Creates the effect proxies for a given animation.
    /// </summary>
    /// <param name="animation"> The animation that we want to get the effects from. </param>
    /// <param name="pixelCount"> The led count of the ledstrip. </param>
    /// <param name="token"> A token to cancel this operation. </param>
    /// <returns> </returns>
    protected virtual async Task<IEnumerable<EffectProxy>> CreateEffectProxies(Animation animation, int pixelCount, CancellationToken token = default)
    {
        _logger.LogDebug($"Creating effect proxies for animation {animation.Id}.");

        try
        {
            List<EffectProxy> result = new List<EffectProxy>();

            foreach (AnimationEffect animationEffect in animation.Effects)
            {
                _logger.LogTrace($"Creating effect {animationEffect.Id}.");

                result.Add(await _effectFactory.CreateEffectProxyAsync(animationEffect, pixelCount, token));
            }

            return result;
        }
        catch (AnimationException animationException)
        {
            // Just throw it no need to add anything here.
            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"There was an error with creating the proxies for animation {animation.Id}.");

            throw;
        }
    }


    /// <inheritdoc />
    public async Task StopAnimationAsync(Guid ledstripId, CancellationToken token = default)
    {
        // Checking if we have an animation player else just return.
        if (!Players.Any(x => x.Ledstrip.Ledstrip.Id == ledstripId))
        {
            _logger.LogWarning("Requested to stop animation that does not exist.");

            return;
        }

        // Getting the animation.
        _logger.LogDebug($"Stopping animation on ledstrip {ledstripId}.");
        IAnimationPlayer existingPlayer = Players.Single(x => x.Ledstrip.Ledstrip.Id == ledstripId);

        try
        {
            // Stopping the animation.
            await existingPlayer.StopAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a problem with stopping animation.");

            throw;
        }

        // Removing the animation from memory.
        Players.Remove(existingPlayer);
        _logger.LogTrace($"Animation on ledstrip {ledstripId} has stopped.");
    }
}