using System;
using System.Linq;

using LedController.Controller.Core.Handlers;
using LedController.Controller.Domain.Animations;
using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Core.Factories;

internal class AnimationPlayerFactory : IAnimationPlayerFactory
{
    private readonly ILoggerFactory _loggerFactory;


    public AnimationPlayerFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }


    /// <inheritdoc />
    public IAnimationPlayer CreateAnimationPlayer(Animation animation, LedstripProxy ledstrip, IEnumerable<EffectProxy> effects)
    {
        return new AnimationPlayer(_loggerFactory.CreateLogger($"Animation Player {Guid.NewGuid()}"), animation, ledstrip, effects);
    }
}