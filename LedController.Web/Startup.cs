using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MudBlazor.Services;



namespace LedController.WebPortal.Web;

public class Startup
{
	/// <summary>
	/// The application configuration
	/// </summary>
	public IConfiguration Configuration { get; }


	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}


	// This method gets called by the runtime. Use this method to add services to the container.
	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMudServices();

		services.AddRazorPages();
		services.AddServerSideBlazor();
	}


	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Error");
		}

		app.UseStaticFiles();

		app.UseRouting();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapBlazorHub();
			endpoints.MapFallbackToPage("/_Host");
		});
	}
}