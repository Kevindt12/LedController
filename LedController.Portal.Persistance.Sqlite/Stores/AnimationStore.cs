using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Contexts;
using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal class AnimationStore : StoreBase<AnimationEntity, Animation>, IAnimationStore
{
	private new readonly ApplicationDbContext _context;


	/// <summary>
	/// The animations that we have in the application.
	/// </summary>
	public AnimationStore(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
	{
		_context = context;
	}


	/// <inheritdoc />
	public void AddAnimationEffect(AnimationEffect animationEffect)
	{
		AnimationEffectEntity entity = _mapper.Map<AnimationEffectEntity>(animationEffect);
		_context.Set<AnimationEffectEntity>().Add(entity);
	}


	/// <inheritdoc />
	public void UpdateAnimationEffect(AnimationEffect animationEffect)
	{
		AnimationEffectEntity entity = _mapper.Map<AnimationEffectEntity>(animationEffect);
		_context.Set<AnimationEffectEntity>().Update(entity);
	}


	/// <inheritdoc />
	public void RemoveAnimationEffect(AnimationEffect animationEffect)
	{
		AnimationEffectEntity entity = _mapper.Map<AnimationEffectEntity>(animationEffect);

		_context.AnimationEffects.Remove(entity);
	}


	/// <inheritdoc />
	public void UpdateAnimationEffectParameterValues(IEnumerable<AnimationEffectParameterValue> parameterValues)
	{
		IEnumerable<AnimationEffectParameterEntity> entities = _mapper.Map<IEnumerable<AnimationEffectParameterEntity>>(parameterValues);

		_context.Set<AnimationEffectParameterEntity>().UpdateRange(entities);
	}


	/// <inheritdoc />
	public Task<bool> Exists(Animation animation, CancellationToken token = default)
	{
		return _set.AnyAsync(a => a.Id == animation.Id, token);
	}
}