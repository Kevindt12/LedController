using System;
using System.Linq;

using LedController.Domain.Effects;
using LedController.Domain.Models;

using UnitsNet;



namespace LedController.Controller.Domain.Proxies;

public class EffectProxy
{
    /// <summary>
    /// A proxy to the effect that can be used.
    /// </summary>
    /// <param name="frequency"> The frequency of the effect that we want to play, </param>
    /// <param name="duration"> The duration of the effect </param>
    /// <param name="effectBase"> The effect implementation. </param>
    public EffectProxy(Frequency frequency,
                       TimeSpan? duration,
                       Effect effect,
                       EffectBase effectBase)
    {
        Frequency = frequency;
        Duration = duration;
        Effect = effect;
        EffectBase = effectBase;
    }


    /// <summary>
    /// The effect that we have this proxy for.
    /// </summary>
    public Effect Effect { get; }

    /// <summary>
    /// The frequency that we want to play the effect at.
    /// </summary>
    /// <remarks>
    /// This is not used when using a static animation.
    /// </remarks>
    public Frequency Frequency { get; }


    /// <summary>
    /// The duration of the effect.
    /// </summary>
    public TimeSpan? Duration { get; }


    /// <summary>
    /// The effect implementation that we are going to use in the animation player.
    /// </summary>
    public EffectBase EffectBase { get; }
}