using System;
using System.Linq;

using FluentValidation;

using LedController.Domain.Models;



namespace LedController.WebPortal.Web.Validation;

public class SpiBusValidator : AbstractValidator<SpiBus>
{
	public SpiBusValidator() { }
}