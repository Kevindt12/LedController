using System;
using System.Reflection;
using System.Linq;

using LedController.Shared.Attributes;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace LedController.Shared.Options;

public class OptionsCollection : IOptionsCollection
{
	/// <summary>
	/// The service collection that we need ot bind options to.
	/// </summary>
	internal IServiceCollection Services { get; }

	/// <summary>
	/// The configuration where we get our options from.
	/// </summary>
	internal IConfiguration Configuration { get; }


	/// <summary>
	/// The options collection that handles getting all the options that we need to configure everything
	/// </summary>
	public OptionsCollection(IConfiguration configuration, IServiceCollection services)
	{
		Services = services;
		Configuration = configuration;
	}


	/// <inheritdoc />
	public void AddOption<TOption>() where TOption : class
	{
		string optionName = typeof(TOption).GetCustomAttribute<OptionAttribute>()?.Name ?? throw new ArgumentOutOfRangeException("The name field cannot be found. Please check your options again.");

		//Services.Configure<TOption>(optionName ,Configuration.GetSection(optionName));

		Services.Configure<TOption>(option => Configuration.GetSection(optionName).Bind(option));
	}
}