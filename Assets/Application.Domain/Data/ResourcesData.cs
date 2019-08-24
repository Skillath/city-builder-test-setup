using System.Collections.Generic;

namespace CityBuilder.Data
{
    public class ResourcesData
    {
        public ResourceType[] Resources { get; set;}
        
    }

    public enum ResourceType : int
    {
        Gold = 0,
        Wood = 1,
        Steel = 2,
    }
}
