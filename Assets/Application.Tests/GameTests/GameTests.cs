using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Views;
using NUnit.Framework;
using System.Collections;
using System.Threading;
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
            var root = Container.TryResolve<IRoot>();
            Assert.That(root, Is.Not.Null);

            var windowNavigation = Container.TryResolve<WindowNavigation>();
            Assert.That(windowNavigation, Is.Not.Null);

            var showTask = windowNavigation.Show<ILoadingView>(CancellationToken.None);
            yield return showTask.AsIEnumerator();
            Assert.That(showTask.IsCompleted && !showTask.IsCanceled && !showTask.IsCanceled);


            var hideTask = windowNavigation.Hide<ILoadingView>(CancellationToken.None);
            yield return hideTask.AsIEnumerator();
            Assert.That(hideTask.IsCompleted && !hideTask.IsCanceled && !hideTask.IsCanceled);

            yield return null;
        }

        [UnityTest]
        [Timeout(3000000)]
        public IEnumerator LoadBuildingsTests()
        {
            var loader = Container.TryResolve<IBuildingLoader>();
            Assert.That(loader, Is.Not.Null);

            yield return null;

            var building = loader.CreateBuilding(CityBuilder.Data.BuildingType.Residence);
            Assert.That(building, Is.Not.Null);

            yield return null;
        }
    }
}