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

using SQLitePCL;



namespace LedController.Core.Managers
{
	public class SpiBusManager : ISpiBusManager
	{
		private readonly ILogger<SpiBusManager> _logger;
		private readonly ApplicationDbContext _context;


		public SpiBusManager(ILogger<SpiBusManager> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}


		public async Task<IEnumerable<SpiBus>> GetSpiBuses(CancellationToken token = default)
		{
			_logger.LogTrace($"Getting all the spi buses in the application.");

			return await _context.SpiBuses.ToListAsync(token);
		}


		public async Task<SpiBus> GetSpiBusById(string id, CancellationToken token = default)
		{
			_logger.LogTrace($"Getting a spi bus by id {id}.");

			return await _context.SpiBuses.SingleAsync(x => x.Id == id, token);
		}


		public async Task AddSpiBus(SpiBus bus, CancellationToken token = default)
		{
			_logger.LogTrace($"Adding a new spi bus {bus.Id} on bus id {bus.BusId} with chip select {bus.ChipSelectId}, with name {bus.Name}.");

			_context.SpiBuses.Add(bus);
			await _context.SaveChangesAsync(token);

		}


		public async Task UpdateSpiBus(SpiBus bus, CancellationToken token = default)
		{
			_logger.LogTrace($"Updating spi bus {bus.Id} on bus id {bus.BusId} with chip select {bus.ChipSelectId}, with name {bus.Name}.");

			_context.SpiBuses.Update(bus);
			await _context.SaveChangesAsync(token);
		}


		public async Task DeleteSpiBus(SpiBus bus, CancellationToken token = default)
		{
			_logger.LogTrace($"Removing spi bus {bus.Id} on bus id {bus.BusId} with chip select {bus.ChipSelectId}, with name {bus.Name}.");

			_context.SpiBuses.Remove(bus);
			await _context.SaveChangesAsync(token);

		}
	}
}
