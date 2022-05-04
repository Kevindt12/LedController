using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.WebPortal.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal class SpiBusStore : StoreBase<SpiBusEntity, SpiBus>, ISpiBusStore
{
	/// <summary>
	/// The spi buses in the application.
	/// </summary>
	public SpiBusStore(IMapper mapper, DbContext context) : base(mapper, context) { }


	/// <inheritdoc />
	public void AddSpiBus(SpiBus spiBus, Controller controller)
	{
		SpiBusEntity spiBusEntity = _mapper.Map<SpiBusEntity>(spiBus);
		ControllerEntity controllerEntity = _mapper.Map<ControllerEntity>(controller);

		controllerEntity.SpiBuses.Add(spiBusEntity);
		_context.Set<SpiBusEntity>().Add(spiBusEntity);
		_context.Set<ControllerEntity>().Update(controllerEntity);
	}
}