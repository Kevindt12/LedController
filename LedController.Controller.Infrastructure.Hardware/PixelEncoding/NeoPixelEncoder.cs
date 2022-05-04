using System;
using System.Drawing;
using System.Linq;



namespace LedController.Controller.Infrastructure.Device.PixelEncoding
{

    public class NeoPixelEncoder : ColorEncoder
    {
        private const int BytesPerComponent = 3;

        private const int BytesPerPixel = BytesPerComponent * 3;

        // The Neo Pixels require a 50us delay (all zeros) after. Since Spi freq is not exactly
        // as requested 100us is used here with good practical results. 100us @ 2.4Mbps and 8bit
        // data means we have to add 30 bytes of zero padding.
        private const int ResetDelayInBytes = 30;


        private static readonly byte[] _lookup = new byte[256 * BytesPerComponent];


        static NeoPixelEncoder()
        {
            for (int i = 0; i < 256; i++)
            {
                int data = 0;

                for (int j = 7; j >= 0; j--)
                {
                    data = (data << 3) | 0b100 | (((i >> j) << 1) & 2);
                }

                _lookup[i * BytesPerComponent + 0] = unchecked((byte)(data >> 16));
                _lookup[i * BytesPerComponent + 1] = unchecked((byte)(data >> 8));
                _lookup[i * BytesPerComponent + 2] = unchecked((byte)(data >> 0));
            }
        }


        public override ReadOnlySpan<byte> Convert(ReadOnlySpan<Color> colors)
        {
            int numberOfBytes = colors.Length * BytesPerPixel;
            byte[] data = CreateDataArray(colors.Length);

            int offset = 0;
            int colorIndex = 0;

            while (offset < numberOfBytes)
            {
                data[offset++] = _lookup[colors[colorIndex].G * BytesPerComponent + 0];
                data[offset++] = _lookup[colors[colorIndex].G * BytesPerComponent + 1];
                data[offset++] = _lookup[colors[colorIndex].G * BytesPerComponent + 2];
                data[offset++] = _lookup[colors[colorIndex].R * BytesPerComponent + 0];
                data[offset++] = _lookup[colors[colorIndex].R * BytesPerComponent + 1];
                data[offset++] = _lookup[colors[colorIndex].R * BytesPerComponent + 2];
                data[offset++] = _lookup[colors[colorIndex].B * BytesPerComponent + 0];
                data[offset++] = _lookup[colors[colorIndex].B * BytesPerComponent + 1];
                data[offset++] = _lookup[colors[colorIndex].B * BytesPerComponent + 2];
                colorIndex++;
            }

            return data;
        }


        /// <summary>
        /// </summary>
        /// <param name="numberOfColors"> The number of colors </param>
        /// <returns> </returns>
        private static byte[] CreateDataArray(int numberOfColors)
        {
            return new byte[numberOfColors * BytesPerPixel + ResetDelayInBytes];
        }
    }
}
