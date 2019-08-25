using CityBuilder.Game.Buildings.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class GridBuildingSpace : MonoBehaviour, IBuildingSpace
    {
        [SerializeField]
        private Transform container;


        public Vector Position => container.localPosition.ToVector();

        public Vector Size { get; set; }
    }
}
