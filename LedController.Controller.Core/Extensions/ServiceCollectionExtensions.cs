using System;
using System.Linq;

using LedController.Controller.Core.Factories;
using LedController.Controller.Core.Services;
using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Options;
using LedController.Controller.Domain.Services;
using LedController.Shared.Options;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.Controller.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCoreOptions(this IOptionsCollection options)
    {
        options.AddOption<DeviceOptions>();
        options.AddOption<DiscoveryOptions>();
        options.AddOption<ServerOptions>();
    }


    public static void AddCoreRunningServices(this IServiceCollection services)
    {
        services.AddSingleton<IAnimationService, AnimationService>();
        services.AddSingleton<IEffectService, EffectService>();
        services.AddSingleton<ILedstripService, LedstripService>();
    }


    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IAnimationPlayerFactory, AnimationPlayerFactory>();
        services.AddSingleton<IEffectFactory, EffectFactory>();
    }
}