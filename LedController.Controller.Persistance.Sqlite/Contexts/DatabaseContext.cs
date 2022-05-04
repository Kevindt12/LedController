using System;
using System.Linq;

using LedController.Domain.Models;

using Microsoft.EntityFrameworkCore;



namespace LedController.Controller.Persistence.Sqlite.Contexts;

internal class DatabaseContext : DbContext
{
#pragma warning disable CS8618
	public DbSet<EffectAssembly> EffectAssemblies { get; set; } = default!;
#pragma warning restore CS8618


	public DatabaseContext()
	{
		Database.EnsureCreated();
	}


	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite("Data Source=Database.db");
		options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}
}