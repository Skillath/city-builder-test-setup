using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Game.Player.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Time;
using Zenject;

namespace UnityCityBuilder.Game.Buildings.ResourceGeneratorTypes.Entities
{
    public class NormalResourceGenerator : MonoBehaviour, IBuildingResourceGenerator
    {
        private ResourcesExchanger resourcesExchanger;
        private ITimeAdapter timeAdapter;
        private BuildingProductionData productionData;

        public bool CanGenerateResource { get; private set; } = true;

        [Inject]
        private void Inject(ResourcesExchanger resourcesExchanger, ITimeAdapter timeAdapter)
        {
            this.resourcesExchanger = resourcesExchanger;
            this.timeAdapter = timeAdapter;
        }

        public void Initialize(BuildingProductionData productionData)
        {
            this.productionData = productionData;
            CanGenerateResource = true;
        }

        public async Task<(ResourceType resource, int quantity)?> GenerateResource(CancellationToken cancellationToken)
        {
            CanGenerateResource = false;
            await timeAdapter.Delay(TimeSpan.FromSeconds(productionData.Seconds), cancellationToken);
            CanGenerateResource = true;

            var generatedResources = (productionData.Resource, productionData.Production);
            resourcesExchanger.AddResources(generatedResources);
            return generatedResources;
        }
    }
}
