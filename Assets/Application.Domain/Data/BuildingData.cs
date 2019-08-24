using System.Collections.Generic;

namespace CityBuilder.Data
{
    public class BuildingData
    {
        public BuildingType Type { get; set; }

        public BuildingCostData[] BuildingCost { get; set; }
        public BuildingProductionData Production { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
    }

    public enum BuildingType : int
    {
        Residence = 0,
        WoodProductionBuilding = 1,
        SteelProductionBuilding = 2,
    }
}
