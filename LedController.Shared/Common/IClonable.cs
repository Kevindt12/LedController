using System;
using System.Linq;



namespace LedController.Shared.Common;

public interface ICloneable<T> : ICloneable
{
	new T Clone();
}