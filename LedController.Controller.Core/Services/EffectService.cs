using System;
using System.Linq;

using LedController.Controller.Domain.Services;
using LedController.Controller.Infrastructure.Providers;
using LedController.Controller.Persistence.Services;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Core.Services;

public class EffectService : IEffectService
{
    private readonly ILogger<EffectService> _logger;
    private readonly IEffectAssemblyProvider _effectAssemblyProvider;


    public EffectService(ILogger<EffectService> logger, IEffectAssemblyProvider effectAssemblyProvider, IRepository repository)
    {
        _logger = logger;
        _effectAssemblyProvider = effectAssemblyProvider;
    }


    /// <inheritdoc />
    public async Task SaveEffectAssembly(ReadOnlyMemory<byte> buffer, EffectAssembly effectAssembly, CancellationToken token = default)
    {
        _logger.LogTrace($"Saving effect assembly {effectAssembly.Id} to disk.");
        await _effectAssemblyProvider.SaveAssemblyAsync(effectAssembly, buffer, token);
    }
}