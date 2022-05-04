using System;
using System.Linq;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

internal class EffectManager : ManagerBase<Effect, IEffectStore>, IEffectManager
{
    private readonly ILogger<EffectManager> _logger;


    public EffectManager(ILogger<EffectManager> logger, IRepository repository, IEffectStore store) : base(logger, repository, store)
    {
        _logger = logger;
    }


    /// <inheritdoc />
    public async Task UnSyncEffectFromAllControllers(Effect effect, CancellationToken token = default)
    {
        _repository.Controllers.RemoveSyncedEffect(effect);

        await _repository.SaveChangesAsync(token);
    }


    /// <inheritdoc />
    public async Task AddEffectParameterAsync(Effect effect, EffectParameter effectParameter, CancellationToken token = default)
    {
        _logger.LogDebug($"Adding parameter to effect {effect.Name}.");

        // Saving so we can add the 
        effect.Parameters.Add(effectParameter);
        _repository.Effects.Update(effect);
        await _repository.SaveChangesAsync(token);
        effectParameter = (await _repository.Effects.GetByIdAsync(effect.Id, token)).Parameters.Last();

        await foreach (Animation animation in _repository.Animations.GetAsync().WithCancellation(token))
        {
            foreach (AnimationEffect animationEffect in animation.Effects)
            {
                animationEffect.Parameters.Add(new AnimationEffectParameterValue
                {
                    EffectParameter = effectParameter,
                    Value = effectParameter.DefaultValue
                });
            }

            _repository.Animations.Update(animation);
        }

        await _repository.SaveChangesAsync(token);
    }


    /// <inheritdoc />
    public async Task RemoveEffectParameterAsync(Effect effect, EffectParameter effectParameter, CancellationToken token = default)
    {
        _logger.LogDebug($"removing parameter to effect {effect.Name}.");

        await _repository.Effects.RemoveEffectParameterAsync(effectParameter, token);
        await _repository.SaveChangesAsync(token);
    }
}