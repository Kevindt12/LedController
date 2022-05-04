using System;
using System.Drawing;
using System.Linq;



namespace LedController.Controller.Infrastructure.Device.PixelEncoding
{
    public abstract class ColorEncoder
    {

        public abstract ReadOnlySpan<byte> Convert(ReadOnlySpan<Color> colors);

    }
}
