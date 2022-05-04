using System;
using System.Linq;

using BlazorMonaco;

using LedController.Domain.Models;
using LedController.WebPortal.Web.Dialogs;

using Microsoft.AspNetCore.Components;

using MudBlazor;



namespace LedController.WebPortal.Web.Components;

public sealed partial class EffectEditor : ComponentBase
{
	private MonacoEditor _editor = default!;
	private EffectParameterRow _effectParameterRow;

	private ICollection<string> _outputLogLines = new List<string>();

	/// <summary>
	/// The effect that we want to edit.
	/// </summary>
	[Parameter]
	public Effect Effect { get; set; } = default!;


	public StandaloneEditorConstructionOptions EditorConstructionOptions(MonacoEditor editor)
	{
		_logger.LogInformation($"Starting monaco editor for effect {Effect!.Name}.");

		return new StandaloneEditorConstructionOptions
		{
			AutomaticLayout = true,
			Language = "csharp",
			Value = Effect!.EffectFile!.Content,
			Theme = "vs-dark"
		};
	}


	/// <inheritdoc />
	protected override void OnInitialized()
	{
		_logger.LogDebug($"Starting effect editor for {Effect!.Name}.");

		base.OnInitialized();
	}


	/// <summary>
	/// Adds a new parameter to the effect.
	/// </summary>
	private async Task AddEffectParameterAsync(EffectParameter parameter)
	{
		_logger.LogDebug($"Adding a new effect parameter for {Effect!.Name}.");

		if (Effect.Parameters.Select(x => x.Name).Contains(parameter.Name)) { }

		parameter = _effectFactory.CreateEffectParameter(parameter.ParameterType, parameter.Name, parameter.Description, parameter.DefaultValue);
		await _effectManager.AddEffectParameterAsync(Effect, parameter);

		_effectParameterRow.Reset();
		StateHasChanged();

		_logger.LogTrace("Effect parameter added.");
		_snackbar.Add("Effect parameter added!", Severity.Success);
	}


	/// <summary>
	/// Removes a parameter from the effect.
	/// </summary>
	/// <param name="parameter"> </param>
	private async Task RemoveEffectParameterAsync(EffectParameter parameter)
	{
		_logger.LogDebug($"Removing effect parameter: {parameter.Name} from effect: {Effect!.Name}.");

		await _effectManager.RemoveEffectParameterAsync(Effect, parameter);

		StateHasChanged();

		_logger.LogTrace("Effect parameter added");
		_snackbar.Add("Removed effect parameter from effect!", Severity.Success);
	}


	private async Task SaveEffectAsync()
	{
		_logger.LogInformation("Saving effect file async.");

		string content = await _editor.GetValue();
		Effect!.EffectFile!.Content = content;
		await _effectManager.Update(Effect);

		_logger.LogInformation("Effect file saved.");
		_snackbar.Add("File Saved!", Severity.Success);
	}


	private async Task BuildEffectAsync()
	{
		_logger.LogInformation($"Building {Effect!.Name}.");
		_snackbar.Add("Building", Severity.Info);

		await _effectService.CompileEffectAsync(Effect);

		_logger.LogInformation($"Build successful for {Effect!.Name}.");
		_snackbar.Add("Build successful", Severity.Success);
	}


	private async Task SyncEffectAsync()
	{
		// Setting dialog the parameters.
		DialogParameters parameters = new DialogParameters
		{
			{ "Effect", Effect }
		};

		// Setting the options for the dialog.
		DialogOptions options = new DialogOptions
		{
			CloseButton = true,
			MaxWidth = MaxWidth.Large,
			FullWidth = true
		};

		DialogResult result = await _dialogService.Show<ControllerEffectSynchronizationDialog>("Sync", parameters, options).Result;

		if (!result.Cancelled)
		{
			_logger.LogInformation("The sync dialog has closed.");
		}
	}


	private IEnumerable<string> GetInvalidParameterNames()
	{
		return Effect.Parameters.Select(x => x.Name);
	}
}