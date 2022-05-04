using System;

using LedController.WebPortal.Core.Extensions;
using LedController.WebPortal.Infrastructure.Connections.Extensions;
using LedController.WebPortal.Persistence.Sqlite.Extensions;

using System.Linq;

using LedController.Shared.Options;

using MudBlazor.Services;

using NLog;
using NLog.Extensions.Logging;



namespace LedController.WebPortal.Web;

public static class Program
{
	public static void Main(string[] args)
	{
		WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

		// Web application and its components.
		ConfigureConfiguration(builder.Configuration);
		ConfigureLogging(builder.Logging, builder.Configuration);
		ConfigureServices(builder.Services);
		ConfigureEnvironment(builder.Environment);
		ConfigureOptions(new OptionsCollection(builder.Configuration, builder.Services));
		ConfigureWebHost(builder.WebHost);
		ConfigureWebHost(builder.WebHost);

		WebApplication app = builder.Build();

		ConfigureWebApplication(app);

		app.Run();
	}


	private static void ConfigureServices(IServiceCollection services)
	{
		// Add middleware
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		services.AddMudBlazorDialog();
		services.AddMudServices();
		services.AddMudBlazorSnackbar();
		services.AddMudPopoverService(x => x.FlipMargin = 2);
		services.AddOptions();
		services.AddInfrastructureMiddlewareServices();

		// Add Application services.
		services.AddPersistenceServices();
		services.AddInfrastructureServices();

		// Adding the running services.
		services.AddCoreServices();
		services.AddInfrastructureServices();

		// Add Blazor
		services.AddRazorPages();
		services.AddServerSideBlazor();
	}


	private static void ConfigureLogging(ILoggingBuilder builder, IConfiguration configuration)
	{
		LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));

		builder.ClearProviders();
		builder.AddNLog();
	}


	private static void ConfigureOptions(IOptionsCollection options)
	{
		options.AddCoreOptions();
	}


	private static void ConfigureConfiguration(ConfigurationManager builder)
	{
		IConfiguration config = builder.SetBasePath(Directory.GetCurrentDirectory())
									   .AddJsonFile("appsettings.json", false, true)
									   .Build();
	}


	private static void ConfigureEnvironment(IWebHostEnvironment environment) { }


	private static void ConfigureWebHost(ConfigureWebHostBuilder builder) { }


	private static void ConfigureWebApplication(WebApplication app)
	{
		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.MapBlazorHub();
		app.MapFallbackToPage("/_Host");
	}
}