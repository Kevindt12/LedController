using System;
using System.Linq;

using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Proxies;
using LedController.Controller.Infrastructure.Device.Proxies;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Infrastructure.Device.Factories;

internal class LedstripFactory : ILedstripFactory
{
    private readonly ILogger<LedstripFactory> _logger;


    /// <summary>
    /// A factory to create ledstrips with the correct protocol to communicate with it/
    /// </summary>
    /// <param name="logger"> </param.
    public LedstripFactory(ILogger<LedstripFactory> logger)
    {
        _logger = logger;
    }


    /// <inheritdoc />
    public LedstripProxy CreateLedstripProxy(Ledstrip ledstrip)
    {
        _logger.LogTrace($"Creating ledstrip proxy of type {nameof(NeoPixelLedstripProxy)}.");

        try
        {
            LedstripProxy proxy = new NeoPixelLedstripProxy(ledstrip);
            _logger.LogTrace("Ledstrip proxy has been created.");

            return proxy;
        }
        catch (IOException ioException)
        {
            _logger.LogError(ioException, $"There was a problem with the SPI bus connection for ledstrip {ledstrip.Id}.");

            throw new LedstripException(ioException, ledstrip);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"There was a problem creating the proxy ledstrip for {ledstrip.Id}");

            throw;
        }
    }
}