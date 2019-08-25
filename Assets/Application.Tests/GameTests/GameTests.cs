using CityBuilder.Core.Entities;
using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Views;
using NUnit.Framework;
using System;
using System.Collections;
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
            await gameStartegy.Load(CancellationToken.None);
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
    }
}