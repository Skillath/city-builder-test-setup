using CityBuilder.Game.Buildings.Entities;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using System.Linq;

namespace CityBuilder.Game.Grid.Adapters
{
    public class GridAdapter
    {
        private readonly int width;
        private readonly int height;

        private readonly IBuildingStrategy[,] buildings;

        public GridAdapter(int width, int height)
        {
            this.width = width;
            this.height = height;

            buildings = new IBuildingStrategy[width, height];
        }

        public bool TrySetBuildingAt(IBuildingStrategy buildingStrategy, Vector gridPosition)
        {
            if (!IsTilesetFree(gridPosition, buildingStrategy.Space.Size))
            {
                return false;
            }

            for (int i = (int)gridPosition.X; i < (int)gridPosition.X + (int)buildingStrategy.Space.Size.X; i++)
            {
                for (int j = (int)gridPosition.Y; j < (int)gridPosition.Y + (int)buildingStrategy.Space.Size.Y; j++)
                {
                    buildings[i, j] = buildingStrategy;
                }
            }

            return true;
        }

        public IBuildingStrategy GetBuildingAt(Vector gridPosition)
        {
            return buildings[(int)gridPosition.X, (int)gridPosition.Y];
        }

        private bool IsInsideBounds(Vector position, Vector size)
        {
            return position.X >= 0 && position.X + size.X < width && position.Y >= 0 && position.Y + size.Y < height;
        }

        private bool IsTilesetFree(Vector position, Vector size)
        {
            if (!IsInsideBounds(position, size))
            {
                return false;
            }

            for (int i = (int)position.X; i < (int)position.X + (int)size.X; i++)
            {
                for (int j = (int)position.Y; j < (int)position.Y + (int)size.Y; j++)
                {
                    if (GetBuildingAt(new Vector(i, j)) != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
