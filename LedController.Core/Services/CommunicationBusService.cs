using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.CommunicationBuses;
using LedController.Domain.Models;



namespace LedController.Core.Services
{
    public class CommunicationBusService : ICommunicationBusService
    {



        /// <summary>
        /// Creates a spi bus connection with this given bus.
        /// </summary>
        /// <param name="bus"></param>
        /// <returns></returns>
        public ISpiBusConnection CreateSpiBusConnection(SpiBus bus)
        {
            return new SpiBusConnection(bus);
        }
    }
}
