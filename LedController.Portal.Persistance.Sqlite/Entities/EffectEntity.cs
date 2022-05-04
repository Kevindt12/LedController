using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class EffectEntity : EntityBase
{
	public string Name { get; set; } = default!;

	public bool IsStatic { get; set; }

	public EffectFileEntity? EffectFile { get; set; }

	public Guid AssemblyId { get; set; }

	public ICollection<EffectParameterEntity> Parameters { get; set; } = default!;


	public ICollection<ControllerEntity> SyncedControllers { get; set; }
}