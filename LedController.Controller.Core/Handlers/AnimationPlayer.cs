using System;
using System.Linq;

using LedController.Controller.Domain.Animations;
using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Proxies;
using LedController.Domain.Effects;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;

using UnitsNet;



namespace LedController.Controller.Core.Handlers;

public sealed class AnimationPlayer : IAnimationPlayer, IDisposable, IAsyncDisposable
{
    private readonly ILogger _logger;


    public Guid Id { get; init; } = Guid.NewGuid();


    // The parts for a background task.
    private Task? _task;
    private CancellationTokenSource? _stoppingToken = new CancellationTokenSource();


    /// <inheritdoc />
    public Animation Animation { get; }

    /// <inheritdoc />
    public IEnumerable<EffectProxy> Effects { get; }

    /// <inheritdoc />
    public LedstripProxy Ledstrip { get; }


    /// <inheritdoc />
    public bool Playing => _task != null;


    /// <summary>
    /// The animation player that will be responsible for playing animation on the ledstrip
    /// </summary>
    public AnimationPlayer(ILogger logger,
                           Animation animation,
                           LedstripProxy ledstrip,
                           IEnumerable<EffectProxy> effects)
    {
        Animation = animation;
        Ledstrip = ledstrip;
        Effects = effects;

        _logger = logger;
    }


    /// <summary>
    /// STarts playing the animation on the controller.
    /// </summary>
    /// <returns> </returns>
    public Task StartAsync()
    {
        _logger.LogTrace($"Starting animation player {Id}.");
        _stoppingToken = new CancellationTokenSource();

        _task = Task.Run(async () =>
        {
            try
            {
                while (!_stoppingToken.IsCancellationRequested)
                {
                    foreach (EffectProxy effect in Effects)
                    {
                        if (!_stoppingToken.IsCancellationRequested) break;

                        await StartEffectAsync(effect);
                    }
                }
            }
            catch (Exception e)
            {
                // Clear the ledstrip then throw the exception to the main task.
                _logger.LogError(e, $"There was a error with playing a animation {Animation.Id}.");
                Ledstrip.Clear();

                throw;
            }
        });

        return Task.CompletedTask;
    }


    /// <summary>
    /// Starts playing the effect proxy.
    /// </summary>
    /// <param name="effect"> The effect proxy that we want to play. </param>
    /// <returns> </returns>
    /// <exception cref="InvalidOperationException"> </exception>
    private async Task StartEffectAsync(EffectProxy effect)
    {
        // Checking if this is a looping effect.

        if (effect.EffectBase is LoopingEffect loopingEffectBase)
        {
            _logger.LogTrace($"Starting looping effect for animation {Id}, with effect {effect.Effect.Id}.");

            try
            {
                await StartLoopingEffectAsync(loopingEffectBase, effect.Duration, effect.Frequency);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"There was a problem with running the effect {effect.Effect.Id}.");

                throw new AnimationException(e, effect.Effect);
            }
        }
        else if (effect.EffectBase is StaticEffect staticEffectBase)
        {
            _logger.LogTrace($"Starting static effect for animation {Id}.");

            try
            {
                await StartStaticEffectAsync(staticEffectBase, effect.Duration);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"There was a problem with running the effect {effect.Effect.Id}.");

                throw new AnimationException(e, effect.Effect);
            }
        }
        else
        {
            throw new AnimationException("The effect was not reconsigned.", effect.Effect);
        }
    }


    /// <summary>
    /// Start the lopping effect.
    /// </summary>
    /// <param name="effect"> The effect base for lopping. </param>
    /// <param name="timeSpan"> The time that we want to run this effect for. </param>
    /// <param name="frequency"> </param>
    /// <returns> </returns>
    private async Task StartLoopingEffectAsync(LoopingEffect effect, TimeSpan? timeSpan, Frequency frequency)
    {
        // Creating the stopping time that we will keep checking to stop.
        TimeOnly stopTime = TimeOnly.FromDateTime(DateTime.Now).Add(timeSpan ?? TimeSpan.MaxValue);

        effect.Setup();

        while (stopTime > TimeOnly.FromDateTime(DateTime.Now) && !_stoppingToken.Token.IsCancellationRequested)
        {
            // The wait time until the next frame. This is done so we have a exact frequency and not process time plus frequency.
            TimeOnly nextFrameTime = TimeOnly.FromDateTime(DateTime.Now).Add(new TimeSpan(0, 0, 0, 0, (int)(1000 / frequency.PerSecond)));

            // Run the effect loop.
            effect.Loop();

            // Setting the ledstrip with the pixels that came out of the effect.
            Ledstrip.Set(effect.Pixels.AsSpan());

            TimeSpan frameTimeLeft = nextFrameTime - TimeOnly.FromDateTime(DateTime.Now);

            // Checks if the render has taken longer then the frequency wait time. If so we contenue.
            // TODO: Maybe add logging to indicate that we are lagging behind.
            if (frameTimeLeft.Ticks < 0)
            {
                continue;
            }

            // Waits until we need to render the next frame.
            await Task.Delay(frameTimeLeft, _stoppingToken.Token);
        }

        // Clears the ledstrip of any colors.
        Ledstrip.Clear();
    }


    /// <summary>
    /// Starts the static effect for the animation that we want to play.
    /// </summary>
    /// <param name="effect"> The base static effect implementation. </param>
    /// <param name="timeSpan"> The duration of the effect. </param>
    /// <returns> </returns>
    private async Task StartStaticEffectAsync(StaticEffect effect, TimeSpan? timeSpan)
    {
        effect.Setup();
        effect.Set();

        PeriodicTimer timer = new PeriodicTimer(timeSpan ?? TimeSpan.MaxValue);
        await timer.WaitForNextTickAsync(_stoppingToken.Token);

        Ledstrip.Clear();
    }


    /// <inheritdoc />
    public async Task StopAsync()
    {
        _logger.LogDebug($"Stopping animation player for animation {Animation.Id} on ledstrip {Ledstrip.Ledstrip.Id}");
        _stoppingToken?.Cancel();

        try
        {
            await _task!;
        }
        catch (AggregateException ae)
        {
            _logger.LogError($"There was a problem with stopping the animation player {Id}.");

            foreach (Exception aeInnerException in ae.InnerExceptions)
            {
                _logger.LogError(aeInnerException, "Problem found with ending animation :");
            }

            throw;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"There was a problem with stopping a animation player {Id}. There was a problem with ending the task of the player.");

            throw;
        }
        finally
        {
            _stoppingToken?.Dispose();
            _task?.Dispose();

            _stoppingToken = null;
            _task = null;
        }
    }


    /// <summary> Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. </summary>
    public void Dispose()
    {
        _stoppingToken?.Dispose();
        _task?.Dispose();

        _stoppingToken = null;
        _task = null;
    }


    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        if (!Playing) return;

        await StopAsync();
    }
}