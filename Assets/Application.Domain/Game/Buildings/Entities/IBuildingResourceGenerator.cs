using CityBuilder.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingResourceGenerator
    {
        bool CanGenerateResource { get; }
        void Initialize(BuildingProductionData productionData);
        Task<(ResourceType resource, int quantity)?> GenerateResource(CancellationToken cancellationToken);
        //void StopResourceGeneration();
    }

    public class BuildingResourceGenerator : IBuildingResourceGenerator
    {
        public static IBuildingResourceGenerator None => new BuildingResourceGenerator();

        public bool CanGenerateResource => false;

        private BuildingResourceGenerator() { }

        public void Initialize(BuildingProductionData productionData)
        {
            //throw new System.NotImplementedException();
        }

        public Task<(ResourceType resource, int quantity)?> GenerateResource(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
