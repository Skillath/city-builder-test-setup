using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingSpace
    {
        Vector LocalPosition { get; }
        Vector GridPosition { get; set; }
        Vector Size { get; set; }
    }
}
