using CityBuilder.Core.Entities;
using CityBuilder.Data;
using CityBuilder.DataProvider;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Game.Player.Entities;
using CityBuilder.Views;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.TestTools;
using WorstGamesStudios.Tests.Common;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace Application.Tests
{
    public class GameTests : CommonIntegrationTest
    {
        [UnityTest]
        [Timeout(3000000)]
        public IEnumerator LoadGameTest()
        {
            var playGame = PlayGame();
            yield return playGame.AsIEnumerator();
            Assert.That(playGame.IsCompleted && !playGame.IsCanceled && !playGame.IsCanceled);
        }

        private async Task PlayGame()
        {
            var root = Container.TryResolve<IRoot>();
            Assert.That(root, Is.Not.Null);

            var windowNavigation = Container.TryResolve<WindowNavigation>();
            Assert.That(windowNavigation, Is.Not.Null);

            var gameLoader = Container.TryResolve<IGameLoader>();
            Assert.That(gameLoader, Is.Not.Null);

            await windowNavigation.Show<ILoadingView>(CancellationToken.None);

            var gameStartegy = await gameLoader.LoadGame(0, CancellationToken.None);
            Assert.That(gameStartegy, Is.Not.Null);
            //await gameStartegy.Load(CancellationToken.None);
            await windowNavigation.Hide<ILoadingView>(CancellationToken.None);
        }

        [UnityTest]
        [Timeout(3000000)]
        public IEnumerator LoadBuildingsTests()
        {
            var loader = Container.TryResolve<IBuildingLoader>();
            Assert.That(loader, Is.Not.Null);

            yield return null;

            var types = (BuildingType[])Enum.GetValues(typeof(BuildingType));

            foreach (var type in types)
            {
                var building = loader.CreateBuilding(type);
                Assert.That(building, Is.Not.Null);
                yield return null;
                var animTask = building.Animator.PlayShowAnimation(CancellationToken.None);
                yield return animTask.AsIEnumerator();
                yield return null;
                Assert.That(animTask.IsCompleted && !animTask.IsCanceled && !animTask.IsFaulted);
            }

            yield return null;
        }

        [UnityTest]
        [Timeout(3000000)]
        public IEnumerator GenerateResourcesTests()
        {
            var loader = Container.TryResolve<IBuildingLoader>();
            Assert.That(loader, Is.Not.Null);
            var player = Container.TryResolve<Player>();
            Assert.That(player, Is.Not.Null);

            var exchange = Container.TryResolve<ResourcesExchanger>();
            Assert.That(exchange, Is.Not.Null);

            var buildingDataProvider = Container.TryResolve<DataProvider<BuildingsData>>();
            Assert.That(loader, Is.Not.Null);
            yield return null;
            var loadTask = buildingDataProvider.GetData();
            yield return loadTask.AsIEnumerator();
            Assert.That(loadTask.IsCompleted && !loadTask.IsCanceled && !loadTask.IsFaulted);
            var buildingData = loadTask.Result;
            Assert.That(buildingData, Is.Not.Null);

            var resourcesDataProvider = Container.TryResolve<DataProvider<ResourcesData>>();
            Assert.That(loader, Is.Not.Null);
            yield return null;
            var resourcesTask = resourcesDataProvider.GetData();
            yield return resourcesTask.AsIEnumerator();
            Assert.That(resourcesTask.IsCompleted && !resourcesTask.IsCanceled && !resourcesTask.IsFaulted);
            var resourcesData = resourcesTask.Result;
            Assert.That(resourcesData, Is.Not.Null);

            yield return null;

            player.InitResources(resourcesData);

            var types = (BuildingType[])Enum.GetValues(typeof(BuildingType));

            foreach (var type in types)
            {
                var building = loader.CreateBuilding(type);
                Assert.That(building, Is.Not.Null);
                yield return null;
                var animTask = building.Animator.PlayShowAnimation(CancellationToken.None);
                yield return animTask.AsIEnumerator();
                yield return null;
                Assert.That(animTask.IsCompleted && !animTask.IsCanceled && !animTask.IsFaulted);
                building.Animator.PlayIdleAnimation();

                var tcs = new TaskCompletionSource<(ResourceType type, int quantity)>();

                void onResourceAdded(ResourceType resourceType, int quantity)
                {
                    logger.Log($"Created {quantity} {resourceType.ToString()}");
                    tcs.SetResult((resourceType, quantity));
                }

                exchange.OnResourceAdded += onResourceAdded;
                _ = building.ResourceGenerator.GenerateResource(CancellationToken.None);
                yield return tcs.Task.AsIEnumerator();
                exchange.OnResourceAdded -= onResourceAdded;
                Assert.That(tcs.Task.IsCompleted && !tcs.Task.IsCanceled);

                var generatedResourceType = tcs.Task.Result.type;
                var taskQuanity = tcs.Task.Result.quantity;
                var productionQuantity = buildingData.Buildings.FirstOrDefault(b => b.Type == type).Production.Quantity;
                Assert.That(taskQuanity == productionQuantity, () => $"{type.ToString()} returned {generatedResourceType.ToString()}{taskQuanity}  but {generatedResourceType.ToString()}{productionQuantity} was expected");
                tcs = null;

                loader.RemoveBuilding(type, building);
            }

            yield return null;


        }
    }
}