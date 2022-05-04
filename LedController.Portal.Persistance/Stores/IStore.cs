using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Stores;

/// <summary>
/// The store of items.
/// </summary>
/// <typeparam name="TModel"> </typeparam>
public interface IStore<TModel>
{
    /// <summary>
    /// Get all the items in the application.
    /// </summary>
    /// <returns> </returns>
    IAsyncEnumerable<TModel> GetAsync();


    /// <summary>
    /// Gets a item by id.
    /// </summary>
    /// <param name="id"> The id of the item. </param>
    /// ///
    /// <param name="token"> A token to stop the current operation. </param>
    /// <returns> </returns>
    Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default);


    /// <summary>
    /// Adding item to database.
    /// </summary>
    /// <param name="item"> The item we want to add. </param>
    void Add(TModel item);


    /// <summary>
    /// Updating item in database.
    /// </summary>
    /// <param name="item"> The item twe want to update. </param>
    void Update(TModel item);


    /// <summary>
    /// Removing the item in the database
    /// </summary>
    /// <param name="item"> The item we want to delete. </param>
    void Remove(TModel item);
}