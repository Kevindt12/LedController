using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.WebPortal.Domain.Services;

/// <summary>
/// Tje effect services.
/// </summary>
public interface IEffectService
{
	/// <summary>
	/// Compiles a effect to get a effect assembly.
	/// </summary>
	/// <param name="effect"> Tje effect that we want to compile. </param>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task CompileEffectAsync(Effect effect, CancellationToken token = default);
}