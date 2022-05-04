using System;
using System.Linq;



namespace LedController.Shared.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class OptionAttribute : Attribute
{
	/// <summary>
	/// The name of the option.
	/// </summary>
	public string Name { get; init; }


	/// <summary>
	/// The options attribute indicating that a class is a options class
	/// </summary>
	/// <param name="name"> </param>
	public OptionAttribute(string name)
	{
		Name = name;
	}
}