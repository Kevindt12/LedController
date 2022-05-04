using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Data.Entities;
using LedController.Domain.Models;

using Microsoft.EntityFrameworkCore;



namespace LedController.Data.Context
{
	public class ApplicationDbContext : DbContext
	{

		/// <summary>
		/// The led strips that are connected to the controller.
		/// </summary>
		public DbSet<Ledstrip> Ledstrips { get; set; }

		/// <summary>
		/// The spi busses known to this device that are in use in this application.
		/// </summary>
		public DbSet<SpiBus> SpiBuses { get; set; }

		/// <summary>
		/// The animation that can be played on a led strip.
		/// </summary>
		public DbSet<AnimationEntity> Animations { get; set; }



		/// <summary>
		/// The application database Context.
		/// </summary>
		public ApplicationDbContext()
		{
			Database.EnsureCreated();

		}



		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=Data.db");
	}
}
