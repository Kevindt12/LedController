using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class AnimationEntity : EntityBase
{
	public string Name { get; set; } = default!;

	public ICollection<AnimationEffectEntity> Effects { get; set; } = default!;
}