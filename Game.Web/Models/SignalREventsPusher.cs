using Game.ActorModel.ExternalSystems;
using Microsoft.AspNet.SignalR;

namespace Game.Web.Models
{
    public class SignalREventsPusher : IGameEventsPusher
    {
        private static readonly IHubContext _gameHubContext;


        static SignalREventsPusher()
        {
            _gameHubContext = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
        }

        public void PlayerJoined(string playerName, int health)
        {
            _gameHubContext.Clients.All.playerJoined(playerName, health);
        }

        public void UpdatePlayerHealth(string playerName, int health)
        {
            _gameHubContext.Clients.All.updatePlayerHealth(playerName, health);
        }
    }
}
