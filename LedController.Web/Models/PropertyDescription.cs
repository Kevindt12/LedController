using System;
using System.Linq;



namespace LedController.WebPortal.Web.Models;

public class PropertyDescription
{
	public Type Type { get; set; }

	public string DisplayName { get; set; }

	public string PropertyName { get; set; }

	public object Value { get; set; }
}