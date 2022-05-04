using System;
using System.Linq;

using AutoMapper;

using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal abstract class StoreBase<TEntity, TModel> : IStore<TModel> where TEntity : EntityBase
{
	protected readonly IMapper _mapper;
	protected readonly DbContext _context;
	protected readonly DbSet<TEntity> _set;


	/// <summary>
	/// The base store class for the stores.
	/// </summary>
	protected StoreBase(IMapper mapper, DbContext context)
	{
		_mapper = mapper;
		_context = context;
		_set = context.Set<TEntity>();
	}


	/// <inheritdoc />
	public virtual async IAsyncEnumerable<TModel> GetAsync()
	{
		await foreach (TEntity item in _context.Set<TEntity>().AsNoTracking().AsAsyncEnumerable())
		{
			TModel model = _mapper.Map<TModel>(item);

			yield return model;
		}
	}


	/// <inheritdoc />
	public virtual async Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default)
	{
		return _mapper.Map<TModel>(await _context.Set<TEntity>().AsNoTracking().SingleAsync(x => x.Id == id, token));
	}


	/// <inheritdoc />
	public virtual void Add(TModel item)
	{
		TEntity entity = _mapper.Map<TEntity>(item);

		_context.Set<TEntity>().Add(entity);
	}


	/// <inheritdoc />
	public virtual void Update(TModel item)
	{
		var test = _mapper.Map<TEntity>(item);

		_context.Set<TEntity>().Update(_mapper.Map<TEntity>(item));
	}


	/// <inheritdoc />
	public virtual void Remove(TModel item)
	{
		_context.Set<TEntity>().Remove(_mapper.Map<TEntity>(item));
	}
}