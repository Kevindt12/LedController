// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace LedController.Portal.Web.Pages.Effects
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
#line 2 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\RainbowEffect.razor"
using Color = System.Drawing.Color;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\RainbowEffect.razor"
using Effect = LedController.Core.Effects.Effect;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\RainbowEffect.razor"
using MudBlazor.Utilities;

#line default
#line hidden
#nullable disable
    public partial class RainbowEffect : EffectComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 27 "D:\Projects\LedController_net5\LedController.Web\Pages\Effects\RainbowEffect.razor"
       


	private Core.Effects.RainbowEffect _effect;


	private ICollection<ColorElement> Colors { get; set; } = new List<ColorElement>();


	public override Effect Effect
	{
		get => (Effect)_effect;
		set => _effect = (Core.Effects.RainbowEffect)value;
	}


	protected virtual void RemoveColor(string id)
	{
		Colors.Remove(Colors.Single(x => x.Id == id));
		StateHasChanged();

	}


	protected virtual void AddColor()
	{
		Colors.Add(new ColorElement());
		StateHasChanged();
	}

	/// <summary>
	/// Method invoked when the component has received parameters from its parent in
	/// the render tree, and the incoming values have been assigned to properties.
	/// </summary>
	protected override void OnParametersSet()
	{
		if (Effect == default)
		{
			_effect = new Core.Effects.RainbowEffect();
			Colors.Add(new ColorElement() { Color = new MudColor(0, 0, 0, 0) });
		}

		if (_effect.Colors != null)
		{
			Colors = _effect.Colors.Select(x => new ColorElement() {Color = new MudColor(x.R, x.G, x.B, byte.MaxValue)}).ToArray();
		}


		base.OnParametersSet();
	}


	protected virtual void SaveEffect()
	{
		_effect.Colors = Colors.Select(x => Color.FromArgb(x.Color.R, x.Color.G, x.Color.B)).ToArray();
	}

	private record ColorElement
	{

		public string Id { get; init; } = Guid.NewGuid().ToString();

		public MudColor Color { get; set; } = new MudColor(0, 0, 0, 0);

	}



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
