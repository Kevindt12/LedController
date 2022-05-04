using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Data.Context;

using Microsoft.Extensions.DependencyInjection;



namespace LedController.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Adds the database services to the application services.
        /// </summary>
        /// <param name="services"></param>
        public static void AddDataServices(this IServiceCollection services)
        {
            // Adding the database to the application.
            services.AddDbContext<ApplicationDbContext>();
        }


    }
}
