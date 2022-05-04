using System;
using System.Linq;



namespace LedController.WebPortal.Web.Enums;

/// <summary>
/// The buttons that we can show on a dialog.
/// </summary>
public enum DialogButtons
{
	/// <summary>
	/// Yes and no button for the dialog.
	/// </summary>
	YesNo = 1,

	/// <summary>
	/// Yes and cancel button for the dialog.
	/// </summary>
	YesCancel = 2,

	/// <summary>
	/// Oke and cancel button for the dialog.
	/// </summary>
	OkCancel = 3,

	/// <summary>
	/// Yes no and cancel button for the dialog.
	/// </summary>
	YesNoCancel = 4
}