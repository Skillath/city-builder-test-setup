using CityBuilder.Common.Utils;
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

        public Vector GridPosition
        {
            get => GridUtils.LocalPositionToGrid(container.localPosition.ToVector(), 10);
            set => container.localPosition = GridUtils.GridToLocalPosition(value, 10).ToVector3();
        }

        public Vector LocalPosition => container.localPosition.ToVector();

        public Vector Size { get; set; }
    }
}
