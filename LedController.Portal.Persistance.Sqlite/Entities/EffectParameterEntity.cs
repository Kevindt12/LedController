using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class EffectParameterEntity : EntityBase
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string PropertyTypeName { get; set; } = default!;

    public string DefaultValue { get; set; } = default!;
}