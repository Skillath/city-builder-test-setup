﻿using CityBuilder.Game.Buildings.Entities;
using UnityCityBuilder.Game.Buildings.ResourceGeneratorTypes.Entities;
using UnityEngine;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class WoodProductionBuilding : BuildingBase
    {
        [SerializeField]
        private NormalResourceGenerator resourceGenerator;

        public override IBuildingResourceGenerator ResourceGenerator => resourceGenerator;

    }
}
