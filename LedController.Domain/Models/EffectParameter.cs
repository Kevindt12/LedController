using System;
using System.Linq;



namespace LedController.Domain.Models;

public class EffectParameter : IEquatable<EffectParameter>
{
    public Guid Id { get; init; }

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The type of parameter.
    /// </summary>
    public Type ParameterType { get; set; }

    /// <summary>
    /// The description of the parameter.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The default fallback value of the parameter.
    /// </summary>
    public object? DefaultValue { get; set; }


    /// <summary>
    /// The parameter that can be used in a effect.
    /// </summary>
    public EffectParameter() { }


    /// <inheritdoc />
    public bool Equals(EffectParameter other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id.Equals(other.Id);
    }


    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((EffectParameter)obj);
    }


    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }


    public static bool operator ==(EffectParameter left, EffectParameter right)
    {
        return Equals(left, right);
    }


    public static bool operator !=(EffectParameter left, EffectParameter right)
    {
        return !Equals(left, right);
    }
}