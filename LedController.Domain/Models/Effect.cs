using System;
using System.Collections.Generic;
using System.Linq;



namespace LedController.Domain.Models;

public class Effect : IEquatable<Effect>
{
    /// <summary>
    /// The id of the effect.
    /// </summary>
    public Guid Id { get; init; }


    /// <summary>
    /// The name of the led strip
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// If the effect is a static effect.
    /// </summary>
    public bool IsStatic { get; set; }

    /// <summary>
    /// The effect file that we have attached to this effect.
    /// </summary>
    public EffectFile? EffectFile { get; set; }


    /// <summary>
    /// Assembly file that we generate from the source file.
    /// </summary>
    public EffectAssembly? EffectAssembly { get; set; }


    /// <summary>
    /// Effect parameters, that we want the user to be able to change for there animation.
    /// </summary>
    public IList<EffectParameter> Parameters { get; set; }


    /// <summary>
    /// The effect that we have.
    /// </summary>
    public Effect()
    {
        Parameters = new List<EffectParameter>();
    }


    /// <inheritdoc />
    public bool Equals(Effect other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id;
    }


    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Effect)obj);
    }


    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }


    public static bool operator ==(Effect left, Effect right)
    {
        return Equals(left, right);
    }


    public static bool operator !=(Effect left, Effect right)
    {
        return !Equals(left, right);
    }
}