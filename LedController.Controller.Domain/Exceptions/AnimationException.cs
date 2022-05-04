using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Exceptions;

public class AnimationException : ApplicationException
{
    /// <summary>
    /// The animation we have a problem with.
    /// </summary>
    public virtual Animation? Animation { get; set; }


    /// <summary>
    /// A effect we had a problem with.
    /// </summary>
    public virtual Effect? Effect { get; set; }


    /// <inheritdoc />
    public AnimationException(Animation animation)
    {
        Animation = animation;
    }


    /// <inheritdoc />
    public AnimationException(string? message, Animation animation) : base(message)
    {
        Animation = animation;
    }


    /// <summary>
    /// An exception that happened with an animation.
    /// </summary>
    /// <param name="message"> The message we want to pass with for this exception. </param>
    /// <param name="innerException"> The inner exepction. </param>
    /// <param name="animation"> The animation of this problem. </param>
    public AnimationException(string? message, Exception? innerException, Animation animation) : base(message, innerException)
    {
        Animation = animation;
    }


    /// <inheritdoc />
    public AnimationException(Effect? effect)
    {
        Effect = effect;
    }


    /// <inheritdoc />
    public AnimationException(string? message, Effect? effect) : base(message)
    {
        Effect = effect;
    }


    /// <inheritdoc />
    public AnimationException(string? message, Exception? innerException, Effect? effect) : base(message, innerException)
    {
        Effect = effect;
    }


    /// <inheritdoc />
    public AnimationException(Exception? innerException, Effect? effect) : base($"There was a problem with a effect {effect.Id}.", innerException)
    {
        Effect = effect;
    }


    /// <summary>
    /// An exception that happened with an animation.
    /// </summary>
    /// <param name="message"> The message we want to pass with for this exception. </param>
    /// <param name="innerException"> The inner exepction. </param>
    /// <param name="animation"> The animation of this problem. </param>
    public AnimationException(Exception? innerException, Animation animation) : base($"There was a problem with {animation.Id}", innerException)
    {
        Animation = animation;
    }


    /// <inheritdoc />
    public AnimationException() { }


    /// <inheritdoc />
    public AnimationException(string? message) : base(message) { }


    /// <inheritdoc />
    public AnimationException(string? message, Exception? innerException) : base(message, innerException) { }
}