using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class AnimationEffectEntity : EntityBase
{
    [ForeignKey(nameof(Animation))]
    public Guid AnimationId { get; set; }

    public AnimationEntity? Animation { get; set; }


    [ForeignKey(nameof(Effect))]
    public Guid EffectId { get; set; }

    public EffectEntity? Effect { get; set; }

    public double Frequency { get; set; }

    public TimeSpan Duration { get; set; }

    public ICollection<AnimationEffectParameterEntity> Parameters { get; set; } = default!;
}