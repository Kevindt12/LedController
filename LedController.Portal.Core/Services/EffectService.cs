using System;

using LamarCodeGeneration;

using System.Linq;
using System.Reflection;

using LamarCompiler;

using LedController.Domain.Effects;
using LedController.Domain.Models;
using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Domain.Services;
using LedController.WebPortal.Infrastructure.Services;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Services;

internal class EffectService : IEffectService
{
	private readonly ILogger<EffectService> _logger;
	private readonly IFileService _fileService;
	private readonly IEffectManager _effectManager;


	public EffectService(ILogger<EffectService> logger, IFileService fileService, IEffectManager effectManager)
	{
		_logger = logger;
		_fileService = fileService;
		_effectManager = effectManager;
	}


	/// <inheritdoc />
	public virtual async Task CompileEffectAsync(Effect effect, CancellationToken token = default)
	{
		_logger.LogTrace($"Compiling effect {effect.Name}.");

		AssemblyGenerator generator = new AssemblyGenerator();

		// This is necessary for the compilation to succeed
		// It's exactly the equivalent of adding references
		// to your project
		generator.ReferenceAssembly(typeof(Console).Assembly);
		generator.ReferenceAssembly(typeof(EffectBase).Assembly);
		generator.ReferenceAssembly(typeof(ILogger).Assembly);
		_logger.LogTrace("References added to assembly generator. ");

		// Compile and generate a new .Net Assembly object
		// in memory
		Assembly assembly = generator.Generate(w => { WriteSourceFile(w, effect); });

		_logger.LogTrace("Assembly compiled.");

		Lokad.ILPack.AssemblyGenerator assemblyGenerator = new Lokad.ILPack.AssemblyGenerator();

		_logger.LogTrace("Saving assembly.");
		Memory<byte> bytes = assemblyGenerator.GenerateAssemblyBytes(assembly);
		await _fileService.SaveAssemblyFileAsync(effect.EffectAssembly!, bytes, token);

		// Update that we have added this assembly.
		await _effectManager.Update(effect);
	}


	protected virtual void WriteSourceFile(ISourceWriter writer, Effect effect)
	{
		// Adding the usngs.
		writer.UsingNamespace<EffectBase>();
		writer.UsingNamespace<ILogger>();

		// Namespace.
		writer.Namespace("LedController.Effects");

		writer.StartClass(EffectBase.GetEffectClassName(effect), effect.IsStatic ? typeof(StaticEffect) : typeof(LoopingEffect));

		writer.Write($"BLOCK:public {EffectBase.GetEffectClassName(effect)}(ILogger logger, int pixelCount, EffectParametersBase parameters) : base(logger, pixelCount, parameters)");
		writer.FinishBlock();

		writer.Write(effect.EffectFile!.Content);

		writer.FinishBlock();

		writer.StartClass(EffectParametersBase.GetEffectClassName(effect), typeof(EffectParametersBase));

		foreach (EffectParameter parameter in effect.Parameters)
		{
			writer.WriteLine($"public {parameter.ParameterType.FullName} {parameter.Name} " + " { get; set; } ");
		}

		writer.FinishBlock();
		writer.FinishBlock();
	}
}