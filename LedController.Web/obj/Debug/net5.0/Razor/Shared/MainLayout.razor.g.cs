#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb4700354bb5918be176d61e3d9764f4fad23399"
// <auto-generated/>
#pragma warning disable 1591
namespace LedController.Web.Shared
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
#line 2 "D:\Projects\LedController_net5\LedController.Web\Shared\MainLayout.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudThemeProvider>(0);
            __builder.CloseComponent();
            __builder.AddMarkupContent(1, "\r\n");
            __builder.OpenComponent<MudBlazor.MudDialogProvider>(2);
            __builder.CloseComponent();
            __builder.AddMarkupContent(3, "\r\n");
            __builder.OpenComponent<MudBlazor.MudSnackbarProvider>(4);
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n\r\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "page");
            __builder.AddAttribute(8, "b-0big2pmett");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "sidebar");
            __builder.AddAttribute(11, "b-0big2pmett");
            __builder.OpenComponent<LedController.Web.Shared.NavMenu>(12);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n\r\n\t");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "main");
            __builder.AddAttribute(16, "b-0big2pmett");
            __builder.AddMarkupContent(17, "<div class=\"top-row px-4\" b-0big2pmett><a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\" b-0big2pmett>About</a></div>\r\n\r\n\t\t");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "content px-4");
            __builder.AddAttribute(20, "b-0big2pmett");
            __builder.AddContent(21, 
#nullable restore
#line 19 "D:\Projects\LedController_net5\LedController.Web\Shared\MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
