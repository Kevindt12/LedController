using System;
using System.CodeDom.Compiler;
using System.Linq;



namespace LedController.WebPortal.Core.Exceptions;

public class CompileErrorException : ApplicationException
{
    /// <summary>
    /// Error while compiling.
    /// </summary>
    public IEnumerable<CompilerError> Errors { get; set; }

    /// <summary>
    /// Time elapsed building.
    /// </summary>
    public TimeSpan CompileTimeElapsed { get; set; }


    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="T:System.SystemException" /> class.
    /// </summary>
    public CompileErrorException(IEnumerable<CompilerError> errors)
    {
        Errors = errors;
    }


    /// <summary>
    /// Initializes a new exception that indicaties a problem with compiling.
    /// </summary>
    public CompileErrorException(IEnumerable<CompilerError> errors, TimeSpan compileTimeElapsed)
    {
        Errors = errors;
        CompileTimeElapsed = compileTimeElapsed;
    }
}