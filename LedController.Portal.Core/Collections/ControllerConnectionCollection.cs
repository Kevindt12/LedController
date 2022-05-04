using System;
using System.Collections.ObjectModel;
using System.Linq;

using LedController.WebPortal.Infrastructure.Connections;



namespace LedController.WebPortal.Core.Collections;

public class ControllerConnectionCollection : Collection<IControllerConnection>
{
	/// <summary>
	/// The collection of controller connections.
	/// </summary>
	public ControllerConnectionCollection() { }
}