using CityBuilder.Game.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace UnityCityBuilder.Game.GameTypes.CityBuilderGame.Entities
{
    public class CityBuilderGame : MonoBehaviour, IGameType
    {
        [SerializeField]
        private Transform cameraPosition;

        private Transform cameraOriginalPosition;

        public Task Init(CancellationToken cancellationToken)
        {
            cameraOriginalPosition = Camera.main.transform.parent;
            Camera.main.transform.SetParent(cameraPosition, false);

            return Task.CompletedTask;
        }

        public Task End(CancellationToken canellationToken)
        {
            Camera.main?.transform?.SetParent(cameraOriginalPosition, false);
            return Task.CompletedTask;
        }

    }
}
