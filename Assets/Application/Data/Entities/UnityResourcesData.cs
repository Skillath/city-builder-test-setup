using CityBuilder.Data;
using System;
using UnityEngine;

namespace UnityCityBuilder.Data.Entities
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnityResourcesData")]

    public class UnityResourcesData : ScriptableObject, IConvertible<ResourcesData>
    {
        public ResourcesData ToData()
        {
            return new ResourcesData()
            {
                Resources = (ResourceType[])Enum.GetValues(typeof(ResourceType)),
            };
        }
    }
}
