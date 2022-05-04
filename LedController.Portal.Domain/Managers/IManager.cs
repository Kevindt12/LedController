using System;
using System.Linq;



namespace LedController.WebPortal.Domain.Managers;

/// <summary>
/// A base manager for items that we need to manage in the application
/// </summary>
/// <typeparam name="TModel"> The item we want to manager </typeparam>
public interface IManager<TModel>
{
	/// <summary>
	/// Gets all the items that we are managing.
	/// </summary>
	/// <returns> The items that the application knows about. </returns>
	IAsyncEnumerable<TModel> GetAsync();


	/// <summary>
	/// Gets a specific item by its id.
	/// </summary>
	/// <param name="id"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default);


	/// <summary>
	/// Adds a new item to the application.
	/// </summary>
	/// <param name="item"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task Add(TModel item, CancellationToken token = default);


	/// <summary>
	/// Updates a existing item in the application
	/// </summary>
	/// <param name="item"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task Update(TModel item, CancellationToken token = default);


	/// <summary>
	/// Removes the item from the application
	/// </summary>
	/// <param name="item"> </param>
	/// <param name="token"> </param>
	/// <returns> </returns>
	Task Remove(TModel item, CancellationToken token = default);
}