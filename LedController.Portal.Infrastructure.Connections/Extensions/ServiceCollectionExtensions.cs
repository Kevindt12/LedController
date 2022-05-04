using System;
using System.Linq;

using LedController.WebPortal.Infrastructure.Connections.Factories;
using LedController.WebPortal.Infrastructure.Connections.Services;
using LedController.WebPortal.Infrastructure.Services;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.WebPortal.Infrastructure.Connections.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adding the infrastructure middleware
    /// </summary>
    public static void AddInfrastructureMiddlewareServices(this IServiceCollection services)
    {
        services.AddGrpc();
    }


    /// <summary>
    /// Adds the infrastructure services.
    /// </summary>
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Adding the application contexts.

        // Adding the Factories.
        services.AddSingleton<ControllerConnectionFactory>();

        // Adding the running services.
        services.AddSingleton<IControllerConnectionService, GrpcControllerConnectionService>();
        services.AddSingleton<IFileService, FileService>();
    }
}