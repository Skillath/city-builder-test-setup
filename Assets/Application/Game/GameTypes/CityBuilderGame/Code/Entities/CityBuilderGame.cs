using CityBuilder.Game.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityCityBuilder.Game.GameTypes.CityBuilderGame.Entities
{
    public class CityBuilderGame : MonoBehaviour, IGameStrategy
    {
        public Task Load(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Unload()
        {
            throw new NotImplementedException();
        }
    }
}
