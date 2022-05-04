using System;
using System.Linq;

using LedController.Controller.Domain.Factories;
using LedController.Controller.Infrastructure.Device.Factories;
using LedController.Controller.Infrastructure.Device.File;
using LedController.Controller.Infrastructure.Device.Providers;
using LedController.Controller.Infrastructure.Providers;
using LedController.Controller.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.Controller.Infrastructure.Device.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureCoreServices(this IServiceCollection services)
    {
        // Adding the Factories.
        services.AddSingleton<ILedstripFactory, LedstripFactory>();

        // Providers
        services.AddSingleton<IEffectAssemblyProvider, EffectAssemblyProvider>();

        // Services
        services.AddSingleton<IFileService, FileService>();
    }
}