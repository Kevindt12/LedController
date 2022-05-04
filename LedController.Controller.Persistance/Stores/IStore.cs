using System;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Persistence.Stores;

public interface IEffectStore
{
	IAsyncEnumerable<EffectAssembly> GetAsync();

	Task<EffectAssembly> GetByIdAsync(Guid id, CancellationToken token = default);

	void Add(EffectAssembly effectAssembly);

	void Update(EffectAssembly effectAssembly);

	void Remove(EffectAssembly effectAssembly);
}