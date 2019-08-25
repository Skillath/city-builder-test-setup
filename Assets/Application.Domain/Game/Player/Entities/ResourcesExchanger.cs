using CityBuilder.Data;
using System;

namespace CityBuilder.Game.Player.Entities
{
    public delegate void ResourcesExchangerEventHandler(ResourceType resourceType, int quantity);

    public class ResourcesExchanger
    {
        public event ResourcesExchangerEventHandler OnResourceAdded;
        public event ResourcesExchangerEventHandler OnResourceRemoved;

        private readonly Player player;

        public ResourcesExchanger(Player player)
        {
            this.player = player;
        }

        public void AddResources(params (ResourceType resourceType, int quantity)[] resources)
        {
            foreach (var (resourceType, quantity) in resources)
            {
                if (!player.Resources.ContainsKey(resourceType))
                {
                    throw new Exception($"Not found {resourceType.ToString()}");
                }

                player.Resources[resourceType] += quantity;
                OnResourceAdded?.Invoke(resourceType, quantity);
            }
        }

        public void RemoveResource(params (ResourceType resourceType, int quantity)[] resources)
        {
            foreach (var (resourceType, quantity) in resources)
            {
                if (player.Resources[resourceType] < quantity)
                {
                    continue;
                }

                player.Resources[resourceType] -= quantity;
                OnResourceRemoved?.Invoke(resourceType, quantity);
            }
        }
    }
}
