using CityBuilder.Data;
using CityBuilder.DataProvider;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using WorstGamesStudios.Tests.Common;

namespace Application.Tests
{
    public class DataTests : CommonIntegrationTest
    {
        [UnityTest]
        public IEnumerator LoadBuildingsData()
        {
            var loader = Container.TryResolve<DataProvider<BuildingsData>>();
            Assert.That(loader, Is.Not.Null);
            yield return null;
            var loadTask = loader.GetData();
            yield return loadTask.AsIEnumerator();
            Assert.That(loadTask.IsCompleted && !loadTask.IsCanceled && !loadTask.IsFaulted);
            var data = loadTask.Result;
            Assert.That(data, Is.Not.Null);
            data = null;
            Resources.UnloadUnusedAssets();
        }
    }
}