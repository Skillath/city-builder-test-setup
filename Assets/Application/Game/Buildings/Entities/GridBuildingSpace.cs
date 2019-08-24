using CityBuilder.Game.Buildings.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class GridBuildingSpace : MonoBehaviour, IBuildingSpace
    {
        [SerializeField]
        private Transform container;

        [SerializeField]
        private Vector2 size;


        public Vector Position => container.localPosition.ToVector();

        public Vector Size => size.ToVector();
    }
}
