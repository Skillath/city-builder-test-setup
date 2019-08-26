using System;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace CityBuilder.Common.Utils
{
    public static class GridUtils
    {
        public static Vector GridToLocalPosition(Vector gridPosition, float size)
        {
            float x = gridPosition.X * size;
            float z = gridPosition.Y * size;

            //float x = (float)(size * Math.Sqrt(3) * (gridPosition.X + 0.5 * ((int)gridPosition.Y & 1)));
            //float y = size * 3 / 2 * gridPosition.Y;
            return new Vector(x, 0, z);
        }

        public static Vector LocalPositionToGrid(Vector gridPosition, float size)
        {
            int x = (int)Math.Round(gridPosition.X / size);
            int y = ((int)Math.Round(gridPosition.Z / size));
            //int q = (int)Math.Round((Math.Sqrt(3) / 3f * gridPosition.X - 1f / 3 * gridPosition.Y) / size);
            //int r = (int)Math.Round((2f / 3 * gridPosition.Y) / size);

            //return CubeToGrid(new Vector(q, -q - r, r));

            return new Vector(x, y);
        }
    }
}
