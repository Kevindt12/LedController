using System;
using System.Linq;

using LedController.WebPortal.Domain.Managers;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Core.Managers;

internal class ManagerBase<TModel, TStore> : IManager<TModel> where TStore : IStore<TModel>
{
    private readonly ILogger _logger;


    protected readonly TStore _store;
    protected readonly IRepository _repository;


    /// <summary>
    /// A base manager for items that we need to manage in the application
    /// </summary>
    public ManagerBase(ILogger logger, IRepository repository, TStore store)
    {
        _logger = logger;
        _repository = repository;
        _store = store;
    }


    /// <inheritdoc />
    public virtual IAsyncEnumerable<TModel> GetAsync()
    {
        _logger.LogTrace($"Getting all items of type {nameof(TModel)}");

        return _store.GetAsync();
    }


    /// <inheritdoc />
    public virtual Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        _logger.LogTrace($"Getting single item of id {id} of type {nameof(TModel)}");

        return _store.GetByIdAsync(id, token);
    }


    /// <inheritdoc />
    public virtual Task Add(TModel item, CancellationToken token = default)
    {
        _logger.LogTrace($"Adding item of type {nameof(TModel)} to the application.");
        _store.Add(item);

        return _repository.SaveChangesAsync(token);
    }


    /// <inheritdoc />
    public virtual Task Update(TModel item, CancellationToken token = default)
    {
        _logger.LogTrace($"updating item of type {nameof(TModel)} in the application.");

        _store.Update(item);

        return _repository.SaveChangesAsync(token);
    }


    /// <inheritdoc />
    public virtual Task Remove(TModel item, CancellationToken token = default)
    {
        _logger.LogTrace($"removing item of type {nameof(TModel)} from the application.");

        _store.Remove(item);

        return _repository.SaveChangesAsync(token);
    }
}