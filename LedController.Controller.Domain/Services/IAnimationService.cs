using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Services;

/// <summary>
/// The service that handles all the actions to do with animations on ledstrips.
/// </summary>
public interface IAnimationService
{
    /// <summary>
    /// Gets the playing animations on the device.
    /// </summary>
    /// <returns> </returns>
    IDictionary<Ledstrip, Animation> GetPlayingAnimations();


    /// <summary>
    /// Gets if there is an animation playing on that ledstrip.
    /// </summary>
    /// <param name="ledstripId"> </param>
    /// <returns> </returns>
    bool IsAnimationPlayingOnLedstrip(Guid ledstripId);


    /// <summary>
    /// Starts playing a animation on the selected ledstrip
    /// </summary>
    /// <param name="ledstrip"> The ledstrip that we want to play it on. </param>
    /// <param name="animation"> The animation that we want to play. </param>
    /// <param name="token"> A token to cancel the current operation of starting the animation. </param>
    /// <returns> </returns>
    Task StartAnimationAsync(Ledstrip ledstrip, Animation animation, CancellationToken token = default);


    /// <summary>
    /// Stop animation that is playing.
    /// </summary>
    /// <param name="ledstripId"> The id of the ledstrip that we want to stop. </param>
    /// <param name="token"> </param>
    /// <returns> </returns>
    Task StopAnimationAsync(Guid ledstripId, CancellationToken token = default);
}