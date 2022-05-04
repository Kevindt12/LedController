using System;
using System.Drawing;
using System.Linq;

using MudBlazor.Utilities;



namespace LedController.WebPortal.Web.Extensions;

public static class ColorExtensions
{
    /// <summary>
    /// Converting a System color to a Mud Color.
    /// </summary>
    /// <returns> </returns>
    public static MudColor ToMudColor(this Color color)
    {
        return new MudColor(color.R, color.G, color.B, color.A);
    }
}