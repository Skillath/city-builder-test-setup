using CityBuilder.Data;
using System.Collections.Generic;

namespace CityBuilder.Game.Player.Entities
{
    public class Player
    {
        public IDictionary<ResourceType, int> Resources { get; }

        public Player()
        {
            Resources = new Dictionary<ResourceType, int>();
        }

        public void InitResources(ResourcesData resourcesData)
        {
            foreach (var resource in resourcesData.Resources)
            {
                Resources.Add(resource, 200);
            }
        }
    }
}
