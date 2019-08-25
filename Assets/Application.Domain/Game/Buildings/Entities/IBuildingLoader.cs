using CityBuilder.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingLoader 
    {
        IBuildingStrategy CreateBuilding(BuildingType buildingType);

        void RemoveBuilding(BuildingType buildingType, IBuildingStrategy building);
    }
}