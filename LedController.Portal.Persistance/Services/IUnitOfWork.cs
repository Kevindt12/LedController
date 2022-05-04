using System;
using System.Linq;



namespace LedController.WebPortal.Persistence.Services;

/// <summary>
/// The unit of work for the peristalsis layer
/// </summary>
public interface IUnitOfWork
{
	/// <summary>
	/// Saves the changes to the database.
	/// </summary>
	/// <param name="token"> A token to stop the current operation. </param>
	/// <returns> </returns>
	Task SaveChangesAsync(CancellationToken token = default);
}