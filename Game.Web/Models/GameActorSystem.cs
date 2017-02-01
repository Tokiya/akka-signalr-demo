using Akka.Actor;
using Game.ActorModel.Actors;
using Game.ActorModel.ExternalSystems;
using System;

namespace Game.Web.Models
{
    public static class GameActorSystem
    {
        private static ActorSystem ActorSystem;
        private static IGameEventsPusher _gameEventsPusher;

        public static void Create()
        {
            _gameEventsPusher = new SignalREventsPusher();
            ActorSystem = ActorSystem.Create("GameSystem");
            ActorReferences.GameCotroller = ActorSystem.ActorSelection("akka.tcp://GameSystem@127.0.0.1:8092/user/GameController")
                 .ResolveOne(TimeSpan.FromSeconds(3))
                .Result;
            ActorReferences.SignalRBridge = ActorSystem.ActorOf(
                Props.Create(() => 
                new SignalRBridgeActor(_gameEventsPusher, ActorReferences.GameCotroller)),"SignalRBridge");
        }

        public static void Shutdown()
        {
            ActorSystem.Terminate();

        }

        public static class ActorReferences
        {
            public static IActorRef GameCotroller { get; set; }

            public static IActorRef SignalRBridge { get; set; }
        }
    }
}
