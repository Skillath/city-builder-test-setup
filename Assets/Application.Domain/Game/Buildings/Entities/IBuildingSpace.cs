using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingSpace
    {
        Vector Position { get; }
        Vector Size { get; set; }
    }
}
