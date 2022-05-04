using System;
using System.Linq;

using LedController.Controller.Persistence.Stores;



namespace LedController.Controller.Persistence.Services;

public interface IRepository : IUnitOfWork
{
	IEffectStore EffectStore { get; }
}