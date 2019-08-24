using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using System;
using System.Collections.Generic;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class BuildingLoader : IBuildingLoader
    {
        private readonly Dictionary<BuildingType, BuildingFactory> loaders = new Dictionary<BuildingType, BuildingFactory>();

        public BuildingLoader(IList<BuildingFactory> pools)
        {
            loaders.Clear();
            foreach (var pool in pools)
            {
                loaders.Add(pool.BuildingType, pool);
            }
        }

        public IBuilding CreateBuilding(BuildingType type)
        {
            var buildingBase = loaders[type].Spawn();
            return buildingBase;
        }

        public void RemoveBuilding(BuildingType buildingType, IBuilding building)
        {
            loaders[buildingType].Despawn((BuildingBase)building);
        }
    }
}