using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LedController.Domain.Models;



namespace LedController.Core.Managers
{
	public interface ILedstripManager
	{

		Task<IEnumerable<Ledstrip>> GetLedstrips(CancellationToken token = default);


		Task<Ledstrip> GetLedstripById(string id, CancellationToken token  = default);


		Task AddLedstrip(Ledstrip ledstrip, CancellationToken token = default);



		Task EditLedstrip(Ledstrip ledstrip, CancellationToken token = default);



		Task RemoveLedstrip(Ledstrip ledstrip, CancellationToken token = default);
	}
}
