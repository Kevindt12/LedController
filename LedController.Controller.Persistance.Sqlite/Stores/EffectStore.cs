using System;
using System.Linq;

using LedController.Controller.Persistence.Stores;
using LedController.Domain.Models;

using Microsoft.EntityFrameworkCore;



namespace LedController.Controller.Persistence.Sqlite.Stores;

internal class EffectStore : IEffectStore
{
	private readonly DbContext _context;


	public EffectStore(DbContext context)
	{
		_context = context;
	}


	/// <inheritdoc />
	public IAsyncEnumerable<EffectAssembly> GetAsync()
	{
		return _context.Set<EffectAssembly>().AsAsyncEnumerable();
	}


	/// <inheritdoc />
	public Task<EffectAssembly> GetByIdAsync(Guid id, CancellationToken token = default)
	{
		return _context.Set<EffectAssembly>().SingleAsync(x => x.Id == id, token);
	}


	/// <inheritdoc />
	public void Add(EffectAssembly effectAssembly)
	{
		_context.Set<EffectAssembly>().Add(effectAssembly);
	}


	/// <inheritdoc />
	public void Update(EffectAssembly effectAssembly)
	{
		_context.Set<EffectAssembly>().Update(effectAssembly);
	}


	/// <inheritdoc />
	public void Remove(EffectAssembly effectAssembly)
	{
		_context.Set<EffectAssembly>().Remove(effectAssembly);
	}
}