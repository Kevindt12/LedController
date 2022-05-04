using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Exceptions;

public class LedstripException : ApplicationException
{
    /// <summary>
    /// The effect there was a problem with.
    /// </summary>
    public virtual Ledstrip Ledstrip { get; init; }


    public LedstripException(Ledstrip ledstrip)
    {
        Ledstrip = ledstrip;
    }


    public LedstripException(string? message, Ledstrip ledstrip) : base(message)
    {
        Ledstrip = ledstrip;
    }


    /// <summary>
    /// A problem that happened with a ledstrip.
    /// </summary>
    /// <param name="message"> The message we want to give with the exception </param>
    /// <param name="innerException"> The Exception that this is wrapped around. </param>
    /// <param name="effect"> The effect where this problem. </param>
    public LedstripException(string? message, Exception? innerException, Ledstrip ledstrip) : base(message, innerException)
    {
        Ledstrip = ledstrip;
    }


    /// <summary>
    /// A problem that happened with a ledstrip.
    /// </summary>
    /// <param name="message"> The message we want to give with the exception </param>
    /// <param name="innerException"> The Exception that this is wrapped around. </param>
    /// <param name="effect"> The effect where this problem. </param>
    public LedstripException(Exception? innerException, Ledstrip ledstrip) : base($"There was a problem with ledstrip {ledstrip.Id}", innerException)
    {
        Ledstrip = ledstrip;
    }


    public LedstripException() { }


    public LedstripException(string? message) : base(message) { }


    public LedstripException(string? message, Exception? innerException) : base(message, innerException) { }
}