#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ba664833158cf102751219ca79c3f4e14a713c6"
// <auto-generated/>
#pragma warning disable 1591
namespace LedController.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using LedController.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using LedController.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\LedController_net5\LedController.Web\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using LedController.Core.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using LedController.Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using LedController.Core.Managers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using LedController.Web.Pages.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using LedController.Core.Animations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
using MudBlazor.Extensions;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/ledstrips")]
    public partial class LedStrips : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
            __builder.AddMarkupContent(2, "<div class=\"col-sm-10\"><h3>LedStrips</h3></div>\r\n\t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-sm-2 align-content-end");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "btn-group");
            __builder.OpenElement(7, "button");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                              NavigateToAdd

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "class", "btn-primary btn btn-lg");
            __builder.AddContent(10, "Add");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n<hr style=\"margin: 20px\">\r\n\r\n");
            __builder.OpenElement(12, "table");
            __builder.AddAttribute(13, "class", "table");
            __builder.AddMarkupContent(14, @"<thead><tr><th scope=""col"">#</th>
			<th scope=""col"">Name</th>
			<th scope=""col"">Pixel Count</th>
			<th scope=""col"">Spi Bus</th>
			<th scope=""col"">Connection status</th>
			<th scope=""col"">Playing animation</th>
			<th scope=""col"">Actions</th></tr></thead>
	");
            __builder.OpenElement(15, "tbody");
#nullable restore
#line 40 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
         foreach (Ledstrip ledstrip in Ledstrips)
		{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "tr");
            __builder.OpenElement(17, "th");
            __builder.AddAttribute(18, "scope", "row");
            __builder.AddContent(19, 
#nullable restore
#line 43 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                             ledstrip.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\t\t\t");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 44 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                 ledstrip.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n\t\t\t");
            __builder.OpenElement(24, "td");
            __builder.AddContent(25, 
#nullable restore
#line 45 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                 ledstrip.PixelCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n\t\t\t");
            __builder.OpenElement(27, "td");
            __builder.AddContent(28, 
#nullable restore
#line 46 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                  ledstrip.SpiBus?.Name ?? "Not Selected"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n\t\t\t");
            __builder.OpenElement(30, "td");
            __builder.AddContent(31, 
#nullable restore
#line 47 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                 ledstrip.PixelCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\t\t\t");
            __builder.OpenElement(33, "td");
            __builder.AddContent(34, 
#nullable restore
#line 48 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                  LedstripService.LedstripConnectionExists(ledstrip) ? "Connected" : "Disconnected"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n\t\t\t");
            __builder.OpenElement(36, "td");
            __builder.AddContent(37, 
#nullable restore
#line 49 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                  AnimationService.DoesAnimationPlayerExist(ledstrip) ? AnimationService.GetAnimationPlayerByLedstrip(ledstrip).Animation.Name :  "No"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n\t\t\t");
            __builder.OpenElement(39, "td");
            __builder.OpenElement(40, "button");
            __builder.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 51 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                    async () => await ShowSelectAnimationDialog(ledstrip)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(42, "class", "btn btn-danger btn-lg");
            __builder.AddContent(43, "Select Animation");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n\t\t\t\t");
            __builder.OpenElement(45, "button");
            __builder.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                    async () => await StartAnimationAsync(ledstrip)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(47, "disabled", 
#nullable restore
#line 52 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                                                                                  !AnimationService.DoesAnimationPlayerExist(ledstrip)

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(48, "class", "btn btn-danger btn-lg");
            __builder.AddContent(49, "Start");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n\t\t\t\t");
            __builder.OpenElement(51, "button");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 53 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                    async () => await StopAnimationAsync(ledstrip)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(53, "disabled", 
#nullable restore
#line 53 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                                                                                 !AnimationService.DoesAnimationPlayerExist(ledstrip)

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(54, "class", "btn btn-danger btn-lg");
            __builder.AddContent(55, "Stop");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n\r\n\r\n\t\t\t\t");
            __builder.OpenElement(57, "button");
            __builder.AddAttribute(58, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 56 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                  () => NavigateToEdit(ledstrip.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(59, "class", "btn btn-primary");
            __builder.AddContent(60, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n\t\t\t\t");
            __builder.OpenElement(62, "button");
            __builder.AddAttribute(63, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 57 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
                                    async () => await NavigateToDelete(ledstrip.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(64, "class", "btn btn-danger");
            __builder.AddContent(65, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 60 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 66 "D:\Projects\LedController_net5\LedController.Web\Pages\LedStrips.razor"
       

	IEnumerable<Ledstrip> Ledstrips { get; set; }


	/// <summary>
	/// Method invoked when the component is ready to start, having received its
	/// initial parameters from its parent in the render tree.
	/// Override this method if you will perform an asynchronous operation and
	/// want the component to refresh when that operation is completed.
	/// </summary>
	/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
	protected override async Task OnInitializedAsync()
	{
		Ledstrips = await LedstripManager.GetLedstrips();

		await base.OnInitializedAsync();
	}



	protected virtual void NavigateToEdit(string id)
	{
		NavigationManager.NavigateTo($"/EditLedstrip/{id}");
	}


	protected virtual async Task ShowSelectAnimationDialog(Ledstrip ledstrip)
	{

		DialogParameters parameters = new DialogParameters() {["ledstrip"] = ledstrip};

		IDialogReference dialog = DialogService.Show<SelectAnimationDialog>("Select Animation", parameters);

		DialogResult result = await dialog.Result;

		if (result.Cancelled)
		{
			return;
		}

		AnimationPlayer player = result.Data.As<AnimationPlayer>();

		StateHasChanged();

	}


	protected virtual async Task StartAnimationAsync(Ledstrip ledstrip)
	{
		AnimationPlayer player = AnimationService.GetAnimationPlayerByLedstrip(ledstrip);

		await player.StartAsync();
	}


	protected virtual async Task StopAnimationAsync(Ledstrip ledstrip)
	{
		AnimationPlayer player = AnimationService.GetAnimationPlayerByLedstrip(ledstrip);

		await player.StopAsync();

	}

	protected virtual async Task NavigateToDelete(string id)
	{
		await LedstripManager.RemoveLedstrip(Ledstrips.Single(x => x.Id == id));
	}


	protected virtual void NavigateToAdd()
	{
		NavigationManager.NavigateTo($"/AddLedstrip");
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAnimationService AnimationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILedstripService LedstripService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILedstripManager LedstripManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService DialogService { get; set; }
    }
}
#pragma warning restore 1591
