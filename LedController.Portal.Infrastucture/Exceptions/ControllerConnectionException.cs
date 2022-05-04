using System;
using System.Linq;

using LedController.WebPortal.Domain.Models;



namespace LedController.WebPortal.Infrastructure.Exceptions;

public class ControllerConnectionException : ApplicationException
{
	/// <summary>
	/// The controller that the connection error with..
	/// </summary>
	public Controller Controller { get; set; }


	/// <inheritdoc />
	public ControllerConnectionException(string? message) : base(message) { }


	/// <inheritdoc />
	public ControllerConnectionException(string? message, Exception? innerException) : base(message, innerException) { }


	/// <inheritdoc />
	public ControllerConnectionException(string? message, Controller controller) : base(message)
	{
		Controller = controller;
	}


	/// <inheritdoc />
	public ControllerConnectionException(string? message, Exception? innerException, Controller controller) : base(message, innerException)
	{
		Controller = controller;
	}
}