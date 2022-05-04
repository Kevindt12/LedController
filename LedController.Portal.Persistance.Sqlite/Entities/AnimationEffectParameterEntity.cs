using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

internal class AnimationEffectParameterEntity : EntityBase
{
	public Guid EffectParameterId { get; set; }


	public string Name { get; set; }


	/// <summary>
	/// The value that has been serialized.
	/// </summary>
	public string SerializedValue { get; set; }
}