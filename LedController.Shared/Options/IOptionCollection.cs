using System;
using System.Linq;



namespace LedController.Shared.Options;

public interface IOptionsCollection
{
	/// <summary>
	/// Adds a option to the application that should be in the configuration file.
	/// </summary>
	/// <typeparam name="TOption"> The option that that should be in the configuration. </typeparam>
	void AddOption<TOption>() where TOption : class;
}