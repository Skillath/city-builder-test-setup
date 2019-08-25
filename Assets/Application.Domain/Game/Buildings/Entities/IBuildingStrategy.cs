using CityBuilder.Data;
using WorstGameStudios.Core.Abstractions.Engine.Selectable;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingStrategy
    {
        IBuildingSpace Space { get; }

        IBuildingAnimator Animator { get; }

        IBuildingResourceGenerator ResourceGenerator { get; }

        void SetBuildingData(BuildingData data);
    }
}
