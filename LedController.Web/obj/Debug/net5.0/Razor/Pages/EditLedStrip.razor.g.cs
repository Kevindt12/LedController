#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a42224acafe24693a01ab33089f2e7c43cdaf31d"
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
#line 3 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
using LedController.Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
using LedController.Core.Managers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/EditLedstrip/{id}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddLedstrip")]
    public partial class EditLedStrip : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 8 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
 if (IsEdit)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<h3>Edit SpiBus</h3>");
#nullable restore
#line 11 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<h3>Add SpiBus</h3>");
#nullable restore
#line 15 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 19 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
                  Ledstrip

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 19 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
                                             async () => await OnValidsubmit()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(6, "<hr>\r\n\t");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "form-group row");
                __builder2.AddMarkupContent(9, "<label for=\"name\" class=\"col-sm-2 col-form-label\">\r\n\t\t\tName\r\n\t\t</label>\r\n\t\t");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "col-sm-10");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(12);
                __builder2.AddAttribute(13, "id", "name");
                __builder2.AddAttribute(14, "class", "form-control");
                __builder2.AddAttribute(15, "placeholder", "Name");
                __builder2.AddAttribute(16, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 27 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
                                    Ledstrip.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Ledstrip.Name = __value, Ledstrip.Name))));
                __builder2.AddAttribute(18, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Ledstrip.Name));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(19, "\r\n\t");
                __builder2.OpenElement(20, "div");
                __builder2.AddAttribute(21, "class", "form-group row");
                __builder2.AddMarkupContent(22, "<label for=\"pixelCount\" class=\"col-sm-2 col-form-label\">\r\n\t\t\tPixel Count\r\n\t\t</label>\r\n\t\t");
                __builder2.OpenElement(23, "div");
                __builder2.AddAttribute(24, "class", "col-sm-10");
                __Blazor.LedController.Web.Pages.EditLedStrip.TypeInference.CreateInputNumber_0(__builder2, 25, 26, "pixelCount", 27, "form-control", 28, "Pixel Count", 29, 
#nullable restore
#line 36 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
                                      Ledstrip.PixelCount

#line default
#line hidden
#nullable disable
                , 30, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Ledstrip.PixelCount = __value, Ledstrip.PixelCount)), 31, () => Ledstrip.PixelCount);
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 41 "D:\Projects\LedController_net5\LedController.Web\Pages\EditLedStrip.razor"
       


	public bool IsEdit => Id != null;

	[Parameter]
	public string Id { get; set; }


    public Ledstrip Ledstrip { get; set; } = new Ledstrip();

	/// <summary>
	/// Method invoked when the component is ready to start, having received its
	/// initial parameters from its parent in the render tree.
	/// Override this method if you will perform an asynchronous operation and
	/// want the component to refresh when that operation is completed.
	/// </summary>
	/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
	protected override async Task OnInitializedAsync()
	{

		if (IsEdit)
		{
		    Ledstrip = await LedstripManager.GetLedstripById(Id);
		}

		await base.OnInitializedAsync();
	}


	protected virtual async Task OnValidsubmit()
	{
	    if (IsEdit)
	    {
	        await LedstripManager.EditLedstrip(Ledstrip);
	    }
	    else
	    {
	        await LedstripManager.AddLedstrip(Ledstrip);
	    }


	}






#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILedstripManager LedstripManager { get; set; }
    }
}
namespace __Blazor.LedController.Web.Pages.EditLedStrip
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputNumber_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "id", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.AddAttribute(__seq2, "placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
