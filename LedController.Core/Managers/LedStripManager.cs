using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LedController.Data.Context;
using LedController.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace LedController.Core.Managers
{
	public class LedstripManager : ILedstripManager
	{
		private readonly ILogger<Ledstrip> _logger;
		private readonly ApplicationDbContext _context;


		public LedstripManager(ILogger<Ledstrip> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}



		public async Task<IEnumerable<Ledstrip>> GetLedstrips(CancellationToken token = default)
		{
			_logger.LogTrace($"Getting all the led strips in the application.");

			return await _context.Ledstrips.ToListAsync(token);
		}


		public async Task<Ledstrip> GetLedstripById(string id, CancellationToken token = default)
		{
			_logger.LogTrace($"Getting a led strip by id {id}");

			return await _context.Ledstrips.SingleAsync(x => x.Id == id, token);
		}


		public async Task AddLedstrip(Ledstrip ledstrip, CancellationToken token = default)
		{
			_logger.LogTrace($"Adding a new led strip with id {ledstrip.Id}, with name {ledstrip.Name}.");

			_context.Ledstrips.Add(ledstrip);
			await _context.SaveChangesAsync(token);
		}


		public async Task EditLedstrip(Ledstrip ledstrip, CancellationToken token = default)
		{
			_logger.LogTrace($"Updating a led strip with id {ledstrip.Id}, with name {ledstrip.Name}.");

			_context.Ledstrips.Update(ledstrip);
			await _context.SaveChangesAsync(token);
		}


		public async Task RemoveLedstrip(Ledstrip ledstrip, CancellationToken token = default)
		{
			_logger.LogTrace($"Removing a led strip with id {ledstrip.Id}, with name {ledstrip.Name}.");

			_context.Ledstrips.Remove(ledstrip);
			await _context.SaveChangesAsync(token);
		}
	}
}
