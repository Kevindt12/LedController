using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Contexts;
using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal class EffectStore : StoreBase<EffectEntity, Effect>, IEffectStore
{
	private new readonly ApplicationDbContext _context;


	/// <summary>
	/// The effects that we have in the application.
	/// </summary>
	/// <param name="mapper"> </param>
	/// <param name="context"> </param>
	public EffectStore(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
	{
		_context = context;
	}


	/// <inheritdoc />
	public async Task RemoveEffectParameterAsync(EffectParameter effectParameter, CancellationToken token = default)
	{
		IEnumerable<AnimationEffectParameterEntity> parameterValueEntity = await _context.AnimationEffectParameters.AsNoTracking().Where(x => x.EffectParameterId == effectParameter.Id).ToListAsync(token);

		_context.AnimationEffectParameters.RemoveRange(parameterValueEntity);
		_context.EffectParameters.Remove(_mapper.Map<EffectParameterEntity>(effectParameter));
	}
}