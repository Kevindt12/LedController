using System;
using System.Linq;

using LedController.Controller.Persistence.Services;
using LedController.Controller.Persistence.Sqlite.Services;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.Controller.Persistence.Sqlite.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// App the persistence layer to the application.
    /// </summary>
    /// <returns> </returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository>();

        return services;
    }
}