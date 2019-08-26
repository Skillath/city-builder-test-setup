using CityBuilder.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Core.Entities
{
    public interface IGameLoader
    {
        Task<IGameType> LoadGame(int scenId, CancellationToken cancellationToken);

        Task Unload();
    }
}
