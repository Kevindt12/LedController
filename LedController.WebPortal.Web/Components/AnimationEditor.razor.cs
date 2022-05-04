using System;

using LedController.WebPortal.Web.Extensions;

using System.Linq;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using Animation = LedController.Domain.Models.Animation;



namespace LedController.WebPortal.Web.Components;

public partial class AnimationEditor : ComponentBase
{
	private int _effectCounter;

	/// <summary>
	/// The animation that we are editing.
	/// </summary>
	[Parameter]
	public Animation Animation { get; set; } = default!;


	public AnimationEditor() { }


	protected virtual async Task DeleteAnimationAsync()
	{
		if (await _dialogService.ShowMessageBox(new MessageBoxOptions
			{
				Title = "Delete Animation",
				Message = "Are you sure you want to remove this animation?",
				YesText = "Yes",
				NoText = "No",
				CancelText = null
			}) == false)
			return;

		_logger.LogInformation($"Animation {Animation.Id} is going to be removed.");
		await _animationManager.Remove(Animation);
		_logger.LogInformation("Animation has been removed.");
		_snackbar.AddSuccess("Animation has bee removed!");

		// Reload the page.
		_navigationManager.NavigateTo("Animations");
	}
}