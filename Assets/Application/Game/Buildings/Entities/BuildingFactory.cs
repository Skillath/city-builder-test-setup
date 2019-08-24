using CityBuilder.Data;
using Zenject;


namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class BuildingFactory : MonoMemoryPool<BuildingBase>
    {
        public BuildingType BuildingType { get; private set; }

        [Inject]
        public BuildingFactory(BuildingType buildingType) : base()
        {
            BuildingType = buildingType;
        }


    }
}
