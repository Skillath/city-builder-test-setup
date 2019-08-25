using CityBuilder.Data;
using CityBuilder.DataProvider;
using CityBuilder.Game.Buildings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class BuildingLoader : IBuildingLoader
    {
        private readonly Dictionary<BuildingType, BuildingFactory> loaders = new Dictionary<BuildingType, BuildingFactory>();
        private BuildingsData data;

        public BuildingLoader(IList<BuildingFactory> pools, DataProvider<BuildingsData> dataProvider)
        {
            LoadData(dataProvider);

            loaders.Clear();
            foreach (var pool in pools)
            {
                loaders.Add(pool.BuildingType, pool);
            }

        }

        private async void LoadData(DataProvider<BuildingsData> dataProvider)
        {
            data = await dataProvider.GetData();
        }

        public IBuildingStrategy CreateBuilding(BuildingType type)
        {
            if (data == null)
            {
                throw new Exception("Data not loaded");
            }

            var buildingData = data.Buildings.FirstOrDefault(b => b.Type == type);

            var buildingBase = loaders[type].Spawn();
            buildingBase.SetBuildingData(buildingData);
            return buildingBase;
        }

        public void RemoveBuilding(BuildingType buildingType, IBuildingStrategy building)
        {
            loaders[buildingType].Despawn((BuildingBase)building);
        }
    }
}