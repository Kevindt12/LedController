using System;
using System.Linq;

using MudBlazor;



namespace LedController.WebPortal.Web.Extensions;

public static class SnackbarExtensions
{
	public static void AddError(this ISnackbar snackbar, string message)
	{
		snackbar.Add(message, Severity.Error);
	}


	public static void AddSuccess(this ISnackbar snackbar, string message)
	{
		snackbar.Add(message, Severity.Success);
	}


	public static void AddInfo(this ISnackbar snackbar, string message)
	{
		snackbar.Add(message, Severity.Info);
	}


	public static void AddNormal(this ISnackbar snackbar, string message)
	{
		snackbar.Add(message);
	}


	public static void AddWarning(this ISnackbar snackbar, string message)
	{
		snackbar.Add(message, Severity.Warning);
	}
}