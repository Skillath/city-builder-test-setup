using CityBuilder.Game.Buildings.Entities;
using UnityCityBuilder.Game.Buildings.ResourceGeneratorTypes.Entities;
using UnityEngine;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class ResidenceBuilding : BuildingBase
    {
        [SerializeField]
        private AutomaticResourceGenerator resourceGenerator;

        public override IBuildingResourceGenerator ResourceGenerator => resourceGenerator;

    }
}
