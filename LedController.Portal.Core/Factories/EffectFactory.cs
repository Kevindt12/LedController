using System;
using System.Drawing;
using System.Linq;

using LedController.Domain.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Diagnostics;



namespace LedController.WebPortal.Core.Factories;

public class EffectFactory
{
	private static readonly string[] _csharpKeywords =
	{
		"bool", "byte", "sbyte", "short", "ushort", "int", "uint", "long", "ulong", "double", "float", "decimal",
		"string", "char", "void", "object", "typeof", "sizeof", "null", "true", "false", "if", "else", "while", "for", "foreach", "do", "switch",
		"case", "default", "lock", "try", "throw", "catch", "finally", "goto", "break", "continue", "return", "public", "private", "internal",
		"protected", "static", "readonly", "sealed", "const", "fixed", "stackalloc", "volatile", "new", "override", "abstract", "virtual",
		"event", "extern", "ref", "out", "in", "is", "as", "params", "__arglist", "__makeref", "__reftype", "__refvalue", "this", "base",
		"namespace", "using", "class", "struct", "interface", "enum", "delegate", "checked", "unchecked", "unsafe", "operator", "implicit", "explicit"
	};

	private static readonly Type[] _validTypes =
	{
		typeof(int), typeof(float), typeof(Color), typeof(Color[])
	};

	private readonly ILogger<EffectFactory> _logger;


	/// <summary>
	/// The effect factory that handles creating new effects.
	/// </summary>
	/// <param name="logger"> </param>
	public EffectFactory(ILogger<EffectFactory> logger)
	{
		_logger = logger;
	}


	/// <summary>
	/// Creates a new effect that we can use in the application.
	/// </summary>
	/// <param name="name"> </param>
	/// <returns> </returns>
	public Effect CreateEffect(string name, bool isStatic)
	{
		_logger.LogDebug("Creating a new effect.");

		Guid effectAssemblyId = Guid.NewGuid();

		return new Effect
		{
			Name = name,
			EffectFile = GenerateNewEffectFile(isStatic),
			EffectAssembly = new EffectAssembly
			{
				Id = effectAssemblyId
			}
		};
	}


	/// <summary>
	/// Creates a new effect parameter.
	/// </summary>
	/// <param name="type"> The type of the parameter. </param>
	/// <param name="name"> The name of the parameter. </param>
	/// <param name="description"> The description of the parameter. </param>
	/// <returns> The effect parameter. </returns>
	public virtual EffectParameter CreateEffectParameter(Type type,
														 string name,
														 string description,
														 object? defaultValue)
	{
		Guard.IsNotNull(type, nameof(type));
		Guard.IsNotNull(name, nameof(name));
		Guard.IsNotNull(description, nameof(description));
		Guard.IsNotNull(defaultValue, nameof(defaultValue));

		ThrowIfNameIsKeyword(name);
		ThrowIfNameDoesNotStartWithCapital(name);

		ThrowIfTypeIsNotValidType(type);

		_logger.LogDebug("Creating new Effect parameter all values are valid.");

		return new EffectParameter
		{
			Name = name,
			Description = description,
			ParameterType = type,
			DefaultValue = defaultValue
		};
	}


	/// <summary>
	/// Generates a code file for the new effect.
	/// </summary>
	/// <param name="isStatic"> </param>
	/// <returns> </returns>
	protected virtual EffectFile GenerateNewEffectFile(bool isStatic)
	{
		return new EffectFile
		{
			Content = isStatic ? GenerateStaticCodeFile() : GenerateLoopingCodeFile()
		};
	}


	/// <summary>
	/// Generates a looping code content for the effect.
	/// </summary>
	/// <returns> </returns>
	protected virtual string GenerateLoopingCodeFile()
	{
		return @"

// The code that we run once before we start the animation.
public override void Setup() { }

// The code that we run every frame.
public override void Loop() { }

			";
	}


	/// <summary>
	/// Generates a static Code content for the effect.
	/// </summary>
	/// <returns> </returns>
	protected virtual string GenerateStaticCodeFile()
	{
		return @"

// The code that we run once before we start the animation.
public override void Setup() { }

// Sets the ledstrip once the setup is done.
public override void Set() { }

			";
	}


	protected virtual void ValidateParameterTypeConstraint(Type type) { }


	/// <summary>
	/// Throws an exception if the name is a keyword in c#.
	/// </summary>
	/// <param name="name"> The name we want to check. </param>
	/// <exception cref="ArgumentException"> Thrown when the name is a c# keyword. </exception>
	private static void ThrowIfNameIsKeyword(string name)
	{
		StringComparer comparer = StringComparer.Ordinal;

		if (_csharpKeywords.Contains(name, comparer))
		{
			throw new ArgumentException("Cannot have a name that is a keyword in c#.", nameof(name));
		}
	}


	/// <summary>
	/// Throws a exception if the name does not start with a capital.
	/// </summary>
	/// <param name="name"> The name that should start with a capital. </param>
	/// <exception cref="ArgumentException"> Thrown when the </exception>
	private static void ThrowIfNameDoesNotStartWithCapital(string name)
	{
		if (!Char.IsUpper(name[0]))
		{
			throw new ArgumentException("The name has to start with a capital letter.", nameof(name));
		}
	}


	/// <summary>
	/// Checks if the type given for the effect parameter is of a valid type.
	/// </summary>
	/// <param name="type"> The type we want to check. </param>
	/// <exception cref="ArgumentOutOfRangeException"> Thrown when the type is not a valid type. </exception>
	private static void ThrowIfTypeIsNotValidType(Type type)
	{
		if (!_validTypes.Contains(type))
		{
			throw new ArgumentOutOfRangeException(nameof(type), $"Cannot create new parameter with the current given type {type}");
		}
	}
}