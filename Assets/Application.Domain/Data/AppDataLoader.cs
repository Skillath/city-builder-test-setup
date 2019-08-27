using CityBuilder.DataProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityBuilder.Data
{
    public class AppDataLoader
    {
        private readonly DataProvider<BuildingsData> buildingDataProvider;
        private readonly DataProvider<ResourcesData> resourcesDataProvider;

        public AppDataLoader(DataProvider<BuildingsData> buildingDataProvider, DataProvider<ResourcesData> resourcesDataProvider)
        {
            this.buildingDataProvider = buildingDataProvider;
            this.resourcesDataProvider = resourcesDataProvider;
        }

        public Task LoadAppData() => Task.WhenAll(buildingDataProvider.GetData(), resourcesDataProvider.GetData());


    }
}
