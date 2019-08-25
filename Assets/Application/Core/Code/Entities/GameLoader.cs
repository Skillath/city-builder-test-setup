using CityBuilder.Core.Entities;
using CityBuilder.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnityCityBuilder.Core.Entities
{
    public class GameLoader : IGameLoader
    {
        public async Task<IGameStrategy> LoadGame(int scenId, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
