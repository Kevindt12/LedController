using System;
using System.Linq;

using LedController.Controller.Persistence.Services;
using LedController.Controller.Persistence.Sqlite.Contexts;
using LedController.Controller.Persistence.Sqlite.Stores;
using LedController.Controller.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.Controller.Persistence.Sqlite.Services;

internal class Repository : IRepository
{
    private readonly ILogger<Repository> _logger;
    private readonly DatabaseContext _context;


	/// <summary>
	/// The repository that will store the application data.
	/// </summary>
	/// <param name="logger"> </param>
	public Repository(ILogger<Repository> logger)
    {
        _logger = logger;
        _context = new DatabaseContext();

        EffectStore = new EffectStore(_context);
    }


    /// <inheritdoc />
    public Task SaveChangesAsync(CancellationToken token = default)
    {
        try
        {
            return _context.SaveChangesAsync(token);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "There was a problem with saving data to the database.");

            throw;
        }
    }


    /// <inheritdoc />
    public IEffectStore EffectStore { get; }
}