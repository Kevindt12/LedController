using System;

using LedController.Controller.Core.Extensions;
using LedController.Controller.Infrastructure.Device.Extensions;
using LedController.Controller.Persistence.Sqlite.Extensions;

using System.Linq;

using LedController.Controller.Service.Services;
using LedController.Shared.Options;

using NLog;
using NLog.Extensions.Logging;



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

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        builder.Services.AddGrpc();

        WebApplication app = builder.Build();

        ConfigureWebApplication(app);

        // Start the application.
        app.Run();
    }


    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddOptions();

        // Core library services
        services.AddPersistenceServices();
        services.AddInfrastructureCoreServices();
        services.AddCoreServices();

        // Adding running services.
        services.AddCoreRunningServices();
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
        app.MapGrpcService<ServerConnectionService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
    }
}