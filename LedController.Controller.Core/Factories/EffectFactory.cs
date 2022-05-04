using System;
using System.Linq;
using System.Reflection;

using LedController.Controller.Domain.Exceptions;
using LedController.Controller.Domain.Factories;
using LedController.Controller.Domain.Proxies;
using LedController.Controller.Infrastructure.Providers;
using LedController.Controller.Persistence.Services;
using LedController.Domain.Effects;
using LedController.Domain.Models;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Core.Factories;

internal class EffectFactory : IEffectFactory
{
	private readonly ILogger<EffectFactory> _logger;
	private readonly ILoggerFactory _loggerFactory;
	private readonly IEffectAssemblyProvider _effectAssemblyProvider;
	private readonly IRepository _repository;


	public EffectFactory(ILogger<EffectFactory> logger,
						 ILoggerFactory loggerFactory,
						 IEffectAssemblyProvider effectAssemblyProvider,
						 IRepository repository)
	{
		_logger = logger;
		_loggerFactory = loggerFactory;
		_effectAssemblyProvider = effectAssemblyProvider;
		_repository = repository;
	}


	/// <inheritdoc />
	public async ValueTask<EffectProxy> CreateEffectProxyAsync(AnimationEffect animationEffect, int pixelCount, CancellationToken token = default)
	{
		// Loading assembly.
		Assembly assembly = await _effectAssemblyProvider.GetAssemblyAsync(animationEffect.Effect.EffectAssembly!, token);
		_logger.LogTrace($"Got assembly {assembly.FullName}.");

		// Get the types that we need to create
		string effectParametersTypeName = EffectParametersBase.GetEffectClassName(animationEffect.Effect);
		string effectBaseTypeName = EffectBase.GetEffectClassName(animationEffect.Effect);
		_logger.LogTrace($"Getting full type name for effect {animationEffect.Animation.Id}. EffectBase Type Name : {effectBaseTypeName}, Effect Parameters Type Name : {effectParametersTypeName}");

		// Getting the type instances from both types.
		Type effectParametersType = assembly.GetType(effectParametersTypeName) ?? throw new AnimationException($"Could not find class {effectBaseTypeName} in assembly {assembly.FullName}.", animationEffect.Animation);
		Type effectBaseType = assembly.GetType(effectBaseTypeName) ?? throw new AnimationException($"Could not find class {effectBaseTypeName} in assembly {assembly.FullName}.", animationEffect.Animation);
		_logger.LogTrace("Found both types in assembly.");

		// Creating instances from both types.
		EffectParametersBase effectParametersBase = CreateEffectParameters(effectParametersType, animationEffect.Parameters);
		EffectBase effectBase = (EffectBase)Activator.CreateInstance(effectBaseType, _loggerFactory.CreateLogger(effectBaseTypeName), pixelCount, effectParametersBase)!;
		_logger.LogTrace("Created from both types an instance.");

		return new EffectProxy(animationEffect.Frequency, animationEffect.Duration, animationEffect.Effect, effectBase);
	}


	/// <summary>
	/// Creates the effect parameter object with its properties set
	/// </summary>
	/// <param name="effectParametersType"> The type name of the effect parameters. </param>
	/// <param name="parameters"> </param>
	/// <returns> </returns>
	protected virtual EffectParametersBase CreateEffectParameters(Type effectParametersType, IEnumerable<AnimationEffectParameterValue> parameterValues)
	{
		EffectParametersBase effectParametersBase = (EffectParametersBase)Activator.CreateInstance(effectParametersType)!;

		foreach (AnimationEffectParameterValue parameterValue in parameterValues)
		{
			if (parameterValue.Value == null) continue;

			typeof(EffectParametersBase).GetProperty(parameterValue.Name)?.SetValue(effectParametersBase, parameterValue.Value);
		}

		return effectParametersBase;
	}
}