using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Exceptions;

public class PersistenceException : ApplicationException
{
    /// <summary>
    /// A exception that is a wrapper for the persistence layer.
    /// </summary>
    /// <param name="message"> The message that we want to send with. </param>
    public PersistenceException(string? message) : base(message) { }


    /// <summary>
    /// A exception that is a wrapper for the persistence layer.
    /// </summary>
    /// <param name="message"> The message that we want to send with. </param>
    /// <param name="innerException"> The inner exception. </param>
    public PersistenceException(string? message, Exception? innerException) : base(message, innerException) { }
}