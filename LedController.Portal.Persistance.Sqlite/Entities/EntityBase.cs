using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



namespace LedController.WebPortal.Persistence.Sqlite.Entities;

public abstract class EntityBase
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
}