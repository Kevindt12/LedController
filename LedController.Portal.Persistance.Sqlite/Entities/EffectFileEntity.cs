using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

public class EffectFileEntity : EntityBase
{
    public string Content { get; set; } = default!;
}