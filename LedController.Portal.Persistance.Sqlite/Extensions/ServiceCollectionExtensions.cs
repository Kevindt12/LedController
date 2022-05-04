using System;
using System.Linq;

using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Sqlite.Services;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.WebPortal.Persistence.Sqlite.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the persistence services to the application.
    /// </summary>
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // Extensions
        services.AddSingleton<IRepository, Repository>();

        services.AddSingleton(provider => provider.GetService<IRepository>()!.Animations);
        services.AddSingleton(provider => provider.GetService<IRepository>()!.Controllers);
        services.AddSingleton(provider => provider.GetService<IRepository>()!.Effects);
        services.AddSingleton(provider => provider.GetService<IRepository>()!.Ledstrips);
        services.AddSingleton(provider => provider.GetService<IRepository>()!.SpiBuses);
    }
}