using System;
using System.Drawing;
using System.Linq;
using System.Text.Json;

using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Proxies;
using LedController.Controller.Domain.Services;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;

using UnitsNet;



namespace LedController.Controller.Core.Services;

internal class LedstripService : ILedstripService
{
    private readonly ILogger<LedstripService> _logger;
    private readonly ILedstripFactory _ledstripFactory;


    public LedstripService(ILogger<LedstripService> logger, ILedstripFactory ledstripFactory)
    {
        _logger = logger;
        _ledstripFactory = ledstripFactory;
    }


    /// <inheritdoc />
    public async Task TestLedstripAsync(Ledstrip ledstrip, CancellationToken token = default)
    {
        _logger.LogDebug($"Testing ledstrip. Ledstrip Data : {JsonSerializer.Serialize(ledstrip)}");

        // Creating proxy
        using LedstripProxy ledstripProxy = _ledstripFactory.CreateLedstripProxy(ledstrip);

        ledstripProxy.Clear();
        ledstripProxy.Set(Enumerable.Repeat(Color.Red, ledstrip.PixelCount).ToArray());
        _logger.LogTrace($"Setting colors on ledstrip {ledstrip.Id} to red.");

        await Task.Delay(Duration.FromSeconds(4).ToTimeSpan(), token);

        ledstripProxy.Clear();
        ledstripProxy.Set(Enumerable.Repeat(Color.Green, ledstrip.PixelCount).ToArray());
        _logger.LogTrace($"Setting colors on ledstrip {ledstrip.Id} to green.");

        await Task.Delay(Duration.FromSeconds(4).ToTimeSpan(), token);

        ledstripProxy.Clear();
        ledstripProxy.Set(Enumerable.Repeat(Color.Blue, ledstrip.PixelCount).ToArray());
        _logger.LogTrace($"Setting colors on ledstrip {ledstrip.Id} to blue.");

        await Task.Delay(Duration.FromSeconds(4).ToTimeSpan(), token);
        ledstripProxy.Clear();

        _logger.LogDebug("Ledstrip test is done.");
    }
}