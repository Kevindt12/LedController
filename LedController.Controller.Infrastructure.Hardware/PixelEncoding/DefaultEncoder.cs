using System;
using System.Drawing;
using System.Linq;



namespace LedController.Controller.Infrastructure.Device.PixelEncoding
{
    public class DefaultEncoder : ColorEncoder
    {
        public override ReadOnlySpan<byte> Convert(ReadOnlySpan<Color> colors)
        {
            throw new NotImplementedException();
        }
    }
}
