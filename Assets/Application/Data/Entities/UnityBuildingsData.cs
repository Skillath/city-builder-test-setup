using CityBuilder.Data;
using System;
using System.Linq;
using UnityEngine;

namespace UnityCityBuilder.Data.Entities
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnityBuildingsData")]
    public class UnityBuildingsData : ScriptableObject, IConvertible<BuildingsData>
    {
        [SerializeField]
        private UnityBuildingData[] buildings;

        public BuildingsData ToData()
        {
            return new BuildingsData()
            {
                Buildings = buildings?.Select(b => b.ToBuildingData()).ToArray(),
            };
        }
    }

    [Serializable]
    public class UnityBuildingData
    {
        [SerializeField]
        private int width;
        [SerializeField]
        private int height;

        [SerializeField]
        private BuildingType buildingType;
        [SerializeField]
        private UnityBuildingCostData[] costData;
        [SerializeField]
        private UnityBuildingProductionData productionData;


        public BuildingData ToBuildingData()
        {
            return new BuildingData()
            {
                Type = buildingType,
                Width = width,
                Height = height,
                BuildingCost = costData.Select(cd => cd.ToBuildingCostData()).ToArray(),
                Production = productionData.ToBuildingProductionData(),
            };
        }
    }

    [Serializable]
    public class UnityBuildingCostData
    {
        [SerializeField]
        private ResourceType resourceType;
        [SerializeField]
        private int cost;

        public BuildingCostData ToBuildingCostData()
        {
            return new BuildingCostData()
            {
                Cost = cost,
                Resource = resourceType,
            };
        }
    }

    [Serializable]
    public class UnityBuildingProductionData
    {
        [SerializeField]
        private ResourceType resourceType;
        [SerializeField]
        private int productionQuantity;
        [SerializeField]
        private int seconds = 10;

        public BuildingProductionData ToBuildingProductionData()
        {
            return new BuildingProductionData()
            {
                Production = productionQuantity,
                Resource = resourceType,
                Seconds = seconds,
            };
        }
    }
}