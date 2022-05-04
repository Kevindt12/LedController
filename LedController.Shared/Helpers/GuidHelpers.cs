using System;
using System.Linq;



namespace LedController.Shared.Helpers;

public static class GuidHelper
{
	/// <summary>
	/// Generates a new GUID to be used in the application.
	/// </summary>
	/// <returns> </returns>
	public static string GenerateGuid()
	{
		return Guid.NewGuid().ToString();
	}
}