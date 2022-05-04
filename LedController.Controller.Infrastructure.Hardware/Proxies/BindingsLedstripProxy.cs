using System;
using System.Device.Spi;
using System.Drawing;
using System.Linq;

using Iot.Device.Ws28xx;

using LedController.Controller.Domain.Proxies;
using LedController.Domain.Models;



namespace LedController.Controller.Infrastructure.Device.Proxies;

internal sealed class NeoPixelLedstripProxy : LedstripProxy, IDisposable
{
    private readonly SpiDevice _spiDevice;
    private readonly Ws2812b _ledstrip;


    public NeoPixelLedstripProxy(Ledstrip ledstrip) : base(ledstrip)
    {
        SpiBus bus = ledstrip.SpiBus!;

        _spiDevice = SpiDevice.Create(new SpiConnectionSettings(bus.BusId, bus.ChipSelectId)
        {
            ClockFrequency = bus.Settings!.ClockSpeed,
            DataBitLength = bus.Settings!.DataBitLength,
            DataFlow = (DataFlow)bus.Settings!.DataFlow,
            Mode = (SpiMode)bus.Settings!.Mode
        });

        _ledstrip = new Ws2812b(_spiDevice, ledstrip.PixelCount);
    }


    /// <inheritdoc />
    public override void Set(ReadOnlySpan<Color> colors)
    {
        for (int i = 0; i < colors.Length; i++)
        {
            _ledstrip!.Image.SetPixel(i, 0, colors[i]);
        }

        _ledstrip!.Update();
    }


    /// <inheritdoc />
    public override void Clear()
    {
        _ledstrip.Image.Clear(Color.Black);
        _ledstrip.Update();
    }


    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _spiDevice.Dispose();
        }

        base.Dispose(disposing);
    }
}