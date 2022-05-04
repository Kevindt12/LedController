using System;
using System.Linq;

using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;



namespace LedController.Controller.Domain.Animations;

/// <summary>
/// The player that holds the state of the of the current playing animation
/// </summary>
public interface IAnimationPlayer : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// The animation that we want to play.
    /// </summary>
    /// <remarks>
    /// This has no functionally Its only used to send back to server what animation this is.
    /// And to keep a copy of the original animation
    /// </remarks>
    Animation Animation { get; }

    /// <summary>
    /// The animation we want to play.
    /// </summary>
    IEnumerable<EffectProxy> Effects { get; }

    /// <summary>
    /// The ledstrip we want to play the animation on.
    /// </summary>
    LedstripProxy Ledstrip { get; }

    /// <summary>
    /// If the player is playing.
    /// </summary>
    bool Playing { get; }


    /// <summary>
    /// Start playing the animation.
    /// </summary>
    /// <returns> </returns>
    Task StartAsync();


    /// <summary>
    /// Stops playing the animation on the ledstrip.
    /// </summary>
    /// <returns> </returns>
    Task StopAsync();
}