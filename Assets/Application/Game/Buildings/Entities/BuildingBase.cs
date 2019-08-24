using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;
using Zenject;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public abstract class BuildingBase : MonoBehaviour, IBuilding
    {
        [SerializeField]
        private DOTweenBuildingAnimator animator;
        [SerializeField]
        private GridBuildingSpace location;



        public IBuildingAnimator Animator => animator;

        public IBuildingSpace Location => location;

        public void SetBuildingData(BuildingData data)
        {
            //throw new System.NotImplementedException();
        }
    }
}