using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedController.Controller.Persistence.Services
{
	public interface IUnitOfWork
	{

		Task SaveChangesAsync(CancellationToken token = default);





	}
}
