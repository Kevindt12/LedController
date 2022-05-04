using System;
using System.Linq;

using LedController.WebPortal.Core.Factories;
using LedController.WebPortal.Core.Managers;
using LedController.WebPortal.Core.Services;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Services;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.WebPortal.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        // Factories.
        services.AddSingleton<EffectFactory>();
        services.AddSingleton<AnimationFactory>();

        // Manages
        services.AddSingleton<IAnimationManager, AnimationManager>();
        services.AddSingleton<IControllerManager, ControllerManager>();
        services.AddSingleton<IEffectManager, EffectManager>();
        services.AddSingleton<ISpiBusManager, SpiBusManager>();
        services.AddSingleton<ILedstripManager, LedstripManager>();
        services.AddSingleton<IConfigurationManager, ConfigurationManager>();

        // Services
        services.AddSingleton<IControllerService, ControllerService>();
        services.AddSingleton<IEffectService, EffectService>();

        services.AddHostedService<DiscoveryService>();
        services.AddSingleton<IDiscoveryService, DiscoveryService>(sp => sp.GetService<DiscoveryService>()!);
    }
}