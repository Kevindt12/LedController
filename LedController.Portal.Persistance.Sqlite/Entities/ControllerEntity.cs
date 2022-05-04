using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class ControllerEntity : EntityBase
{
    public string Name { get; set; } = default!;

    public string IpAddress { get; set; } = default!;

    public int Port { get; set; }

    public ICollection<SpiBusEntity> SpiBuses { get; set; } = default!;

    public ICollection<LedstripEntity> Ledstrips { get; set; } = default!;

    public ICollection<EffectEntity> SyncedEffects { get; set; } = default!;
}