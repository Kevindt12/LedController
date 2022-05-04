using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

using LedController.Domain.Effects;
using LedController.WebPortal.Web.Models;

using Microsoft.AspNetCore.Components;



namespace LedController.WebPortal.Web.Components;

public partial class EffectEditor : ComponentBase
{
	/// <summary>
	/// The effect parameters..
	/// </summary>
	[Parameter]
	public EffectParameters EffectParameters { get; set; }

	/// <summary>
	/// The properties that we
	/// </summary>
	protected virtual IEnumerable<PropertyDescription> Properties { get; set; }

	/// <summary>
	/// A callback that we can use when we save.
	/// </summary>
	[Parameter]
	public Func<EffectParameters, Task> SaveCallback { get; set; }


	/// <summary>
	/// Method invoked when the component is ready to start, having received its
	/// initial parameters from its parent in the render tree.
	/// Override this method if you will perform an asynchronous operation and
	/// want the component to refresh when that operation is completed.
	/// </summary>
	/// <returns> A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation. </returns>
	protected override Task OnInitializedAsync()
	{
		Properties = GetSettingsProperties(EffectParameters);

		return base.OnInitializedAsync();
	}


	/// <summary>
	/// Gets all the settings properties.
	/// </summary>
	/// <param name="parameters"> The properties that we need to get the parameters for. </param>
	/// <returns> </returns>
	protected virtual IEnumerable<PropertyDescription> GetSettingsProperties(EffectParameters parameters)
	{
		ICollection<PropertyDescription> result = new List<PropertyDescription>();

		foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
		{
			result.Add(new PropertyDescription { Type = propertyInfo.GetType(), DisplayName = propertyInfo.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? propertyInfo.Name, PropertyName = propertyInfo.Name, Value = propertyInfo.GetValue(parameters) });
		}

		return result;
	}


	/// <summary>
	/// Saves the effect parameters to the object that was supplied.
	/// </summary>
	/// <returns> </returns>
	protected virtual void SaveEffectParameters()
	{
		foreach (PropertyInfo propertyInfo in EffectParameters.GetType().GetProperties())
		{
			propertyInfo.SetValue(EffectParameters, Properties.Single(x => x.PropertyName == propertyInfo.Name));
		}
	}
}