using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Entities;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Contexts;

internal class ApplicationDbContext : DbContext
{
	public ApplicationDbContext()
	{
		//Database.EnsureDeleted();

		Database.EnsureCreated();
	}


	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite("Data Source=Database.db");
		options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}


	/// <inheritdoc />
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Animation Entity
		modelBuilder.Entity<AnimationEntity>().Navigation(e => e.Effects).AutoInclude();

		// Animation Effect Effect
		modelBuilder.Entity<AnimationEffectEntity>().Navigation(e => e.Animation).AutoInclude();
		modelBuilder.Entity<AnimationEffectEntity>().Navigation(e => e.Effect).AutoInclude();
		modelBuilder.Entity<AnimationEffectEntity>().Navigation(e => e.Parameters).AutoInclude();

		// Controller
		modelBuilder.Entity<ControllerEntity>().Navigation(e => e.SpiBuses).AutoInclude();
		modelBuilder.Entity<ControllerEntity>().Navigation(e => e.Ledstrips).AutoInclude();
		modelBuilder.Entity<ControllerEntity>().Navigation(e => e.SyncedEffects).AutoInclude();

		// Effect
		modelBuilder.Entity<EffectEntity>().Navigation(e => e.EffectFile).AutoInclude();
		modelBuilder.Entity<EffectEntity>().Navigation(e => e.Parameters).AutoInclude();

		// Ledstrip
		modelBuilder.Entity<LedstripEntity>().Navigation(e => e.SpiBus).AutoInclude();

		base.OnModelCreating(modelBuilder);
	}


	public DbSet<EffectEntity> Effects { get; set; } = default!;

	public DbSet<EffectFile> EffectFiles { get; set; } = default!;

	public DbSet<EffectParameterEntity> EffectParameters { get; set; } = default!;

	public DbSet<AnimationEntity> Animations { get; set; } = default!;


	public DbSet<ControllerEntity> Controllers { get; set; } = default!;

	public DbSet<AnimationEffectEntity> AnimationEffects { get; set; } = default!;


	public DbSet<AnimationEffectParameterEntity> AnimationEffectParameters { get; set; } = default!;

	public DbSet<LedstripEntity> Ledstrips { get; set; } = default!;

	public DbSet<SpiBusEntity> SpiBuses { get; set; } = default!;
}