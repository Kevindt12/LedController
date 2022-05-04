#pragma checksum "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5aadb03658936e0f745d707fb67484f05c6a01b"
// <auto-generated/>
#pragma warning disable 1591
namespace LedController.Web.Pages.Dialogs
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
#line 1 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
using LedController.Core.Effects;

#line default
#line hidden
#nullable disable
    public partial class AddEffectModal : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudDialog>(0);
            __builder.AddAttribute(1, "TitleContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudText>(2);
                __builder2.AddAttribute(3, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 5 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                       Typo.h6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudIcon>(5);
                    __builder3.AddAttribute(6, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 6 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                            Icons.Material.Filled.DeleteForever

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(7, "Class", "mr-3 mb-n1");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(8, "\r\n\t\t\tDelete server?\r\n\t\t");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(9, "DialogContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudSelect<EffectType>>(10);
                __builder2.AddAttribute(11, "Label", "Select Effect");
                __builder2.AddAttribute(12, "value", 
#nullable restore
#line 11 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                                               EffectType

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(13, "valueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => EffectType = __value, EffectType));
                __builder2.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 12 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
             foreach (EffectType type in Enum.GetValues(typeof(EffectType)))
			{

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MudBlazor.MudSelectItem<EffectType>>(15);
                    __builder3.AddAttribute(16, "value", 
#nullable restore
#line 14 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                                                      type

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseComponent();
#nullable restore
#line 15 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
			}

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(17, "DialogActions", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudButton>(18);
                __builder2.AddAttribute(19, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                            Cancel

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(21, "Cancel");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n\t\t");
                __builder2.OpenComponent<MudBlazor.MudButton>(23);
                __builder2.AddAttribute(24, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 20 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                          Color.Success

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(25, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
                                                  EffectSelected

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(27, "Add Effect");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "D:\Projects\LedController_net5\LedController.Web\Pages\Dialogs\AddEffectModal.razor"
       

    [CascadingParameter]
    MudDialogInstance MudDialog { get; set; }


    public EffectType EffectType { get; set; }


    private void Cancel()
    {
        MudDialog.Cancel();
    }


    private void EffectSelected()
    {
    //In a real world scenario this bool would probably be a service to delete the item from api/database
        MudDialog.Close(DialogResult.Ok(EffectType));
    }



#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
