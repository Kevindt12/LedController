using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal class ControllerStore : StoreBase<ControllerEntity, Controller>, IControllerStore
{
	/// <summary>
	/// The controllers in the application.
	/// </summary>
	/// <param name="mapper"> </param>
	/// <param name="context"> </param>
	public ControllerStore(IMapper mapper, DbContext context) : base(mapper, context) { }


	/// <inheritdoc />
	public void RemoveSyncedEffect(Effect effect)
	{
		foreach (ControllerEntity controllerEntity in _context.Set<ControllerEntity>())
		{
			controllerEntity.SyncedEffects.Remove(_context.Set<EffectEntity>().Single(x => x.Id == effect.Id));
			_context.Attach(controllerEntity);
		}
	}


	/// <inheritdoc />
	public async Task<Controller> GetControllerBySpiBusAsync(SpiBus spiBus, CancellationToken token = default)
	{
		SpiBusEntity spiBusEntity = await _context.Set<SpiBusEntity>().SingleAsync(x => x.Id == spiBus.Id, token);

		return _mapper.Map<Controller>(await _context.Set<ControllerEntity>().SingleAsync(x => x.SpiBuses.Contains(spiBusEntity), token));
	}
}