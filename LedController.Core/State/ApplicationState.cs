using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LedController.Core.Animations;
using LedController.Core.Ledstrips;



namespace LedController.Core.State
{
    public class ApplicationState
    {


        /// <summary>
        /// All the aninmation players that we have.
        /// </summary>
        public ConcurrentBag<AnimationPlayer> AnimationPlayers { get; protected set; }


        /// <summary>
        /// The led strip connection that are active.
        /// </summary>
        public ConcurrentBag<ILedstripConnection> LedstripConnections { get; protected set; }


        /// <summary>
        /// This is the state of the application and the active things that are being used.
        /// </summary>
        public ApplicationState()
        {
            AnimationPlayers = new ConcurrentBag<AnimationPlayer>();
            LedstripConnections = new ConcurrentBag<ILedstripConnection>();
        }


    }
}
