using System;
using System.Drawing;
using System.Linq;

using MudBlazor.Utilities;



namespace LedController.WebPortal.Web.Extensions;

public static class MudColorExtensions
{
    /// <summary>
    /// Converts the MudBlazor color to  <![CDATA[System.Drawing.Color]]>
    /// ///
    /// </summary>
    /// <param name="color"> </param>
    /// <returns> </returns>
    public static Color ToColor(this MudColor color)
    {
        return Color.FromArgb(color.A, color.R, color.G, color.B);
    }
}