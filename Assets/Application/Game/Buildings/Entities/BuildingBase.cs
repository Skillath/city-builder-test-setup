using CityBuilder.Data;
using CityBuilder.Game.Buildings.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public abstract class BuildingBase : MonoBehaviour, IBuildingStrategy
    {
        [SerializeField]
        private DOTweenBuildingAnimator animator;
        [SerializeField]
        private GridBuildingSpace space;

        private BuildingData data;

        public IBuildingAnimator Animator => animator;

        public IBuildingSpace Space => space;

        public abstract IBuildingResourceGenerator ResourceGenerator { get; }

        public void SetBuildingData(BuildingData data)
        {
            this.data = data;

            ResourceGenerator.Initialize(this.data.Production);
            Space.Size = new Vector(this.data.Width, 0, this.data.Height);
        }

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void OnDisable() { }

    }
}