using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using LedController.Domain.Models;




namespace LedController.Core.Managers
{
	public interface ISpiBusManager
	{

		Task<IEnumerable<SpiBus>> GetSpiBuses(CancellationToken token = default);

		Task<SpiBus> GetSpiBusById(string id, CancellationToken token = default);


		Task AddSpiBus(SpiBus bus, CancellationToken token = default);


		Task UpdateSpiBus(SpiBus bus, CancellationToken token = default);

		Task DeleteSpiBus(SpiBus bus, CancellationToken token = default);




	}
}
