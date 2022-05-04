using System;
using System.Linq;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// Manages the configuration for the application.
/// </summary>
public interface IConfigurationManager
{
	/// <summary>
	/// Updates the settings made to the object given to the drive.
	/// </summary>
	/// <remarks>
	/// The options has to have a attribute of
	/// <see cref="LedController.Shared.Attributes.OptionAttribute"> </see>>
	/// </remarks>
	/// <exception cref="InvalidOperationException">
	/// If the class that we are passing in does not contain a
	/// <see cref="LedController.Shared.Attributes.OptionAttribute"> </see> attribute
	/// </exception>
	/// <typeparam name="T"> The type of option that we want to pass in. </typeparam>
	/// <param name="option"> The current values of the option. </param>
	/// ///
	/// <param name="token"> A token to stop the current operation. </param>
	Task UpdateOptions<T>(T option, CancellationToken token = default);
}