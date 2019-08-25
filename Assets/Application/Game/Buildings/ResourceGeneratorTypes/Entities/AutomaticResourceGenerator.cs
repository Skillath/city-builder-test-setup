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
    public class AutomaticResourceGenerator : MonoBehaviour, IBuildingResourceGenerator
    {
        private ResourcesExchanger resourcesExchanger;
        private ITimeAdapter timeAdapter;
        private BuildingProductionData productionData;

        public bool CanGenerateResource => false;

        [Inject]
        private void Inject(ResourcesExchanger resourcesExchanger, ITimeAdapter timeAdapter)
        {
            this.resourcesExchanger = resourcesExchanger;
            this.timeAdapter = timeAdapter;
        }

        public void Initialize(BuildingProductionData productionData)
        {
            this.productionData = productionData;
        }

        public async Task<(ResourceType resource, int quantity)?> GenerateResource(CancellationToken cancellationToken)
        {
            _ = GenerateResourcesIndefinitelly(cancellationToken);
            await Task.Yield();
            return (productionData.Resource, productionData.Quantity);
        }

        private async Task GenerateResourcesIndefinitelly(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested || !this.gameObject.activeInHierarchy)
            {
                return;
            }

            while (!cancellationToken.IsCancellationRequested && this.gameObject.activeInHierarchy)
            {
                await timeAdapter.Delay(TimeSpan.FromSeconds(productionData.Seconds), cancellationToken);

                var generatedResources = (productionData.Resource, productionData.Quantity);
                resourcesExchanger.AddResources(generatedResources);
            }
        }
    }
}
