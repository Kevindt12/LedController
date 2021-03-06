using System;
using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;



namespace LedController.WebPortal.Web;

public class Program
{
	public static void Main(string[] args)
	{
		CreateHostBuilder(args).Build().Run();
	}


	public static IHostBuilder CreateHostBuilder(string[] args)
	{
		return Host.CreateDefaultBuilder(args)
				   .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
	}
}