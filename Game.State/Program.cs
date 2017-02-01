using Akka.Actor;
using Game.ActorModel.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.State
{
    class Program
    {
        private static ActorSystem ActorSystemInstance;

        static void Main(string[] args)
        {
            ActorSystemInstance = ActorSystem.Create("GameSystem");

            var gameController = ActorSystemInstance.ActorOf<GameControllerActor>("GameController");
            Console.ReadLine();
        }
    }
}
