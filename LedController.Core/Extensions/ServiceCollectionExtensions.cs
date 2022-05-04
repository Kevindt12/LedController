using System;
using System.Linq;

using LedController.Core.Factories;
using LedController.Core.Managers;
using LedController.Core.Services;
using LedController.Core.State;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.Core.Extensions;

public static class ServiceCollectionExtensions
{
	public static void AddCoreServices(this IServiceCollection services)
	{
		// Adds the data services to the application.
		services.AddDataServices();

		services.AddSingleton<ApplicationState>();

		services.AddSingleton<AnimationPlayerFactory>();
		services.AddSingleton<LedstripConnectionFactory>();

		services.AddScoped<ILedstripManager, LedstripManager>();
		services.AddScoped<ISpiBusManager, SpiBusManager>();
		services.AddScoped<IAnimationManager, AnimationManager>();

		services.AddScoped<IAnimationService, AnimationService>();
		services.AddScoped<ILedstripService, LedstripService>();
		services.AddScoped<ICommunicationBusService, CommunicationBusService>();
	}
}