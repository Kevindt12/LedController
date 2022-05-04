#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "794929930ccff1ec15d641ec2648a3ad7c31fde2"
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
#line 2 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
using LedController.Core.Managers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
using LedController.Core.Animations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
using Animation = LedController.Core.Animations.Animation;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/animations")]
    public partial class Animations : Microsoft.AspNetCore.Components.ComponentBase
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
#line 14 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
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
            __builder.AddMarkupContent(14, "<thead><tr><th scope=\"col\">#</th>\r\n\t\t\t<th scope=\"col\">Name</th>\r\n\t\t\t<th scope=\"col\">Pixel Count</th>\r\n\t\t\t<th scope=\"col\">Spi Bus</th>\r\n\t\t\t<th scope=\"col\">Actions</th></tr></thead>\r\n\t");
            __builder.OpenElement(15, "tbody");
#nullable restore
#line 32 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
         foreach (Animation animation in AnimationEntries)
		{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "tr");
            __builder.OpenElement(17, "th");
            __builder.AddAttribute(18, "scope", "row");
            __builder.AddContent(19, 
#nullable restore
#line 35 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                                 animation.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n\t\t\t\t");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 36 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                     animation.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n\t\t\t\t");
            __builder.OpenElement(24, "td");
            __builder.AddContent(25, 
#nullable restore
#line 37 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                     animation.Frequency

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n\t\t\t\t");
            __builder.OpenElement(27, "td");
            __builder.AddContent(28, 
#nullable restore
#line 38 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                      animation.IsStatic ? "Static" : "Dynamic"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(30, "<td>PlaceHolder For EffectType</td>\r\n\r\n\t\t\t\t");
            __builder.OpenElement(31, "td");
            __builder.OpenElement(32, "button");
            __builder.AddAttribute(33, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 43 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                                      () => NavigateToEditor(animation.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "class", "btn btn-primary");
            __builder.AddContent(35, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n\t\t\t\t\t");
            __builder.OpenElement(37, "button");
            __builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 44 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
                                        async () => await NavigateToDelete(animation.Id)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "class", "btn btn-danger");
            __builder.AddContent(40, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 47 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"

		}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 54 "D:\Projects\LedController_net5\LedController.Web\Pages\Animations.razor"
       

	IEnumerable<Animation> AnimationEntries { get; set; }


	/// <summary>
	/// Method invoked when the component is ready to start, having received its
	/// initial parameters from its parent in the render tree.
	/// Override this method if you will perform an asynchronous operation and
	/// want the component to refresh when that operation is completed.
	/// </summary>
	/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
	protected override async Task OnInitializedAsync()
	{
	    AnimationEntries = await AnimationManager.GetAnimationsAsync();

		await base.OnInitializedAsync();
	}



	protected virtual void NavigateToEditor(string id)
	{
		NavigationManager.NavigateTo($"/AnimationEditor/{id}");
	}


	protected virtual async Task NavigateToDelete(string id)
	{
		await AnimationManager.RemoveAnimation(AnimationEntries.Single(x => x.Id == id));
	}


	protected virtual void NavigateToAdd()
	{
		NavigationManager.NavigateTo($"/AnimationEditor");
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAnimationManager AnimationManager { get; set; }
    }
}
#pragma warning restore 1591