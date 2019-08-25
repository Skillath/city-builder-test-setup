using CityBuilder.Data;

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
            foreach (var operation in resources)
            {
                player.Resources[operation.resourceType] += operation.quantity;
                OnResourceAdded?.Invoke(operation.resourceType, operation.quantity);
            }
        }

        public void RemoveResource(params (ResourceType resourceType, int quantity)[] resources)
        {
            foreach (var operation in resources)
            {
                if (player.Resources[operation.resourceType] < operation.quantity)
                {
                    continue;
                }

                player.Resources[operation.resourceType] -= operation.quantity;
                OnResourceRemoved?.Invoke(operation.resourceType, operation.quantity);
            }
        }
    }
}
