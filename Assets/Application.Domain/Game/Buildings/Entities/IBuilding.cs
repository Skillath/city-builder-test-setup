using CityBuilder.Data;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuilding
    {
        IBuildingSpace Location { get; }

        IBuildingAnimator Animator { get; }

        void SetBuildingData(BuildingData data);
    }
}
