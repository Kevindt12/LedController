#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5749ff348ce529ffc5164b70e49a363c5d9235d"
// <auto-generated/>
#pragma warning disable 1591
namespace LedController.Web.Pages.Effects
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
#line 2 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
using LedController.Core.Effects;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
using MudBlazor.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
using Color = System.Drawing.Color;

#line default
#line hidden
#nullable disable
    public partial class StaticEffect : EffectComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Static Effect</h3>\r\n\r\n\r\n\r\n");
            __builder.OpenComponent<MudBlazor.MudColorPicker>(1);
            __builder.AddAttribute(2, "Label", "Color");
            __builder.AddAttribute(3, "PickerVariant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.PickerVariant>(
#nullable restore
#line 12 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
                                             PickerVariant.Static

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "ColorPickerView", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ColorPickerView>(
#nullable restore
#line 12 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
                                                                                    ColorPickerView.Grid

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "DisableAlpha", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
                                                                                                                                             true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Utilities.MudColor>(
#nullable restore
#line 12 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
                                                                                                                       _color

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<MudBlazor.Utilities.MudColor>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<MudBlazor.Utilities.MudColor>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _color = __value, _color))));
            __builder.CloseComponent();
            __builder.AddMarkupContent(8, "\r\n\r\n");
            __builder.OpenElement(9, "button");
            __builder.AddAttribute(10, "class", "btn-primary btn");
            __builder.AddAttribute(11, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
                                          SaveEffect

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(12, "Save ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\StaticEffect.razor"
       


	private Core.Effects.StaticEffect _effect;

	private MudColor _color;

	public override Effect Effect
	{
		get => (Effect)_effect;
		set => _effect = (Core.Effects.StaticEffect)value;
	}


	/// <summary>
	/// Method invoked when the component has received parameters from its parent in
	/// the render tree, and the incoming values have been assigned to properties.
	/// </summary>
	protected override void OnParametersSet()
	{
		if (Effect == default)
		{
			_effect = new Core.Effects.StaticEffect();
		}

	    _color = new MudColor(_effect.Color.R, _effect.Color.G, _effect.Color.B, byte.MaxValue);


		base.OnParametersSet();
	}


	protected virtual void SaveEffect()
	{
	    _effect.Color = Color.FromArgb(_color.R, _color.G, _color.B);
	}



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591