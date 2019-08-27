using CityBuilder.Data;
using CityBuilder.Game.Player.Entities;
using CityBuilder.Views;
using WorstGameStudios.Core.Engine.UI;
using Zenject;

namespace UnityCityBuilder.Views
{
    public class PlayerView : View, IPlayerView
    {
        private Player player;
        private ResourcesExchanger resourcesExchanger;

        [Inject]
        private void Inject(Player player, ResourcesExchanger resourceExchanger)
        {
            this.player = player;
            this.resourcesExchanger = resourceExchanger;
        }

        

        public void Initialize()
        {
            resourcesExchanger.OnResourceAdded += ResourcesExchanger_OnResourceAdded;
            resourcesExchanger.OnResourceRemoved += ResourcesExchanger_OnResourceRemoved;
        }

        private void ResourcesExchanger_OnResourceRemoved(ResourceType resourceType, int quantity)
        {

        }

        private void ResourcesExchanger_OnResourceAdded(ResourceType resourceType, int quantity)
        {

        }

        public void Stop()
        {
            resourcesExchanger.OnResourceAdded += ResourcesExchanger_OnResourceAdded;
            resourcesExchanger.OnResourceRemoved += ResourcesExchanger_OnResourceRemoved;
        }

    }
}
