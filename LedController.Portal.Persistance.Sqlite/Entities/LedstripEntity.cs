using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

public class LedstripEntity : EntityBase
{
	public string Name { get; set; } = default!;

	public int PixelCount { get; set; }


	[ForeignKey(nameof(SpiBus))]
	public Guid? SpiBusId { get; set; }

	public SpiBusEntity? SpiBus { get; set; }
}