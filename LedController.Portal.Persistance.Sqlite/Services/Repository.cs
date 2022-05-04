using System;
using System.Data.Common;
using System.Linq;

using AutoMapper;

using LedController.WebPortal.Persistence.Exceptions;
using LedController.WebPortal.Persistence.Services;
using LedController.WebPortal.Persistence.Sqlite.Contexts;
using LedController.WebPortal.Persistence.Sqlite.Stores;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.Extensions.Logging;



namespace LedController.WebPortal.Persistence.Sqlite.Services;

internal class Repository : IRepository
{
	private readonly ILogger<Repository> _logger;
	private readonly IMapper _mapper;
	private readonly ApplicationDbContext _context;


	/// <summary>
	/// The repository of this application.
	/// </summary>
	public Repository(ILogger<Repository> logger, IMapper mapper)
	{
		_logger = logger;
		_mapper = mapper;
		_context = new ApplicationDbContext();

		Animations = new AnimationStore(_mapper, _context);
		Controllers = new ControllerStore(_mapper, _context);
		Effects = new EffectStore(_mapper, _context);
		Ledstrips = new LedstripStore(_mapper, _context);
		SpiBuses = new SpiBusStore(_mapper, _context);
	}


	/// <inheritdoc />
	public async Task SaveChangesAsync(CancellationToken token = default)
	{
		try
		{
			await _context.SaveChangesAsync(token);

			_context.ChangeTracker.Clear();
		}
		catch (DbException dbException)
		{
			_logger.LogError(dbException, "There was a error while saving changes to the database.");

			if (dbException.InnerException != null)
			{
				_logger.LogError(dbException.InnerException, "The inner exception of the database exception.");
			}

			throw new PersistenceException("There was a problem saving data to the database.", dbException);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "There was a problem with saving data to the database. But this was not a database problem.");

			throw;
		}
	}


	/// <inheritdoc />
	public IAnimationStore Animations { get; }

	/// <inheritdoc />
	public IControllerStore Controllers { get; }

	/// <inheritdoc />
	public IEffectStore Effects { get; }

	/// <inheritdoc />
	public ILedstripStore Ledstrips { get; }

	/// <inheritdoc />
	public ISpiBusStore SpiBuses { get; }
}