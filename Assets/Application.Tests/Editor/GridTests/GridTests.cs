using CityBuilder.Common.Utils;
using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Game.Grid.Adapters;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using UnityEngine.TestTools;
using WorstGamesStudios.Tests.Common;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace Application.Tests.Editor
{
    public class GridTests : CommonUnitTests
    {
        private IBuildingStrategy[] buildings;
        private GridAdapter gridAdapter;


        public override void Construct()
        {
            base.Construct();

            gridAdapter = new GridAdapter(10, 10);

            var buildingTypes = (BuildingType[])Enum.GetValues(typeof(BuildingType));

            buildings = new IBuildingStrategy[buildingTypes.Length];
            for (int i = 0; i < buildings.Length; i++)
            {
                buildings[i] = CreateBuildingMoq(buildingTypes[i], new Vector(i + 1, i + 1));
            }

            Assert.That(buildings, Is.Not.Null.Or.Empty);
        }

        private IBuildingStrategy CreateBuildingMoq(BuildingType buildingType, Vector size)
        {
            Vector position = It.IsAny<Vector>();

            var buildingMock = new Mock<IBuildingStrategy>();
            var spaceMock = new Mock<IBuildingSpace>();
            spaceMock.SetupGet(s => s.Size).Returns(size);
            spaceMock.SetupSet(s => s.GridPosition = position);
            spaceMock.SetupGet(s => s.GridPosition).Returns(position);
            var buildingSpace = spaceMock.Object;
            Assert.That(buildingSpace, Is.Not.Null);

            buildingMock.SetupGet(b => b.Space).Returns(buildingSpace);

            return buildingMock.Object;
        }


        [Test]
        public void GridToLocalPositionTest()
        {
            float size = 2.5f;

            var gridPositionZero = new Vector(0, 0);
            var gridPositionOne = new Vector(1, 1);
            var gridPositionFive = new Vector(5, 5);

            var localPositionZero = GridUtils.GridToLocalPosition(gridPositionZero, size);
            Assert.That(localPositionZero == new Vector(), () => $"Expected {new Vector()} but got {localPositionZero}");

            var localPositionOne = GridUtils.GridToLocalPosition(gridPositionOne, size);
            Assert.That(localPositionOne == new Vector(size, 0, size), () => $"Expected {new Vector(size, 0, size)} but got {localPositionOne}");

            var localPositionFive = GridUtils.GridToLocalPosition(gridPositionFive, size);
            var result = new Vector(gridPositionFive.X * size, 0, gridPositionFive.Y * size);
            Assert.That(localPositionFive == result, () => $"Expected {result} but got {localPositionFive}");
        }

        [Test]
        public void LocalPositionToGridTest()
        {
            float size = 2.5f;

            var gridPositionZero = new Vector(0, 0, 0);
            var gridPositionOne = new Vector(size, 0, size);
            var gridPositionFive = new Vector(5 * size, 0, 5 * size);

            var localPositionZero = GridUtils.LocalPositionToGrid(gridPositionZero, size);
            Assert.That(localPositionZero == new Vector(), () => $"Expected {new Vector()} but got {localPositionZero}");

            var localPositionOne = GridUtils.LocalPositionToGrid(gridPositionOne, size);
            Assert.That(localPositionOne == new Vector(1, 1), () => $"Expected {new Vector(1, 1)} but got {localPositionOne}");

            var localPositionFive = GridUtils.LocalPositionToGrid(gridPositionFive, size);
            var result = new Vector((int)Math.Round(gridPositionFive.X / size), (int)Math.Round(gridPositionFive.Z / size));
            Assert.That(localPositionFive == result, () => $"Expected {result} but got {localPositionFive}");
        }

        [Test]
        public void PlaceBuildingTest()
        {
            for (int i = 0; i < buildings.Length; i++)
            {
                var currentBuilding = buildings[i];

                Vector position = new Vector();
                if (i > 0)
                {
                    var previousBuilding = buildings[i - 1];
                    position = new Vector(previousBuilding.Space.GridPosition.X + previousBuilding.Space.Size.X, 0);
                }

                bool setupDone = gridAdapter.TrySetBuildingAt(currentBuilding, position);

                Assert.That(setupDone, () => $"Setup error at {i}, position {position} was taken.");
                currentBuilding.Space.GridPosition = position;
            }



            bool placed = gridAdapter.TrySetBuildingAt(buildings.FirstOrDefault(), new Vector(0, 1));
            Assert.That(placed, () => $"The tileset was not free at {new Vector(0, 1)}");

            placed = gridAdapter.TrySetBuildingAt(buildings.LastOrDefault(), new Vector(3, 3));
            Assert.That(!placed, () => $"The tileset was free at {new Vector(3, 3)}");

            placed = gridAdapter.TrySetBuildingAt(buildings.FirstOrDefault(), new Vector(5, 0));
            Assert.That(placed, () => $"The tileset was not free at {new Vector(5, 0)}");

        }
    }
}
