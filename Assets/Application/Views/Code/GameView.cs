using CityBuilder.Views;
using UnityEngine;
using WorstGameStudios.Core.Engine.UI;

namespace UnityCityBuilder.Views
{
    public class GameView : View, IGameView
    {
        [SerializeField]
        private PlayerView playerView;
        [SerializeField]
        private ModesView modesView;

        public IPlayerView PlayerView => playerView;
        public IModesView ModesView => modesView;
    }
}