using CityBuilder.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorstGameStudios.Core.Engine.UI;

namespace UnityCityBuilder.Views
{
    public class GameView : View, IGameView
    {
        [SerializeField]
        private PlayerView playerView;

        public IPlayerView PlayerView => playerView;
    }
}