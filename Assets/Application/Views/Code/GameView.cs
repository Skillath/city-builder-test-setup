using System.Threading;
using System.Threading.Tasks;
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


        public override Task Show(CancellationToken cancellationToken)
        {
            _ = PlayerView.Show(cancellationToken);
            _ = modesView.Show(cancellationToken);
            return base.Show(cancellationToken);
        }

        public override Task Hide(CancellationToken cancellationToken)
        {
            _ = PlayerView.Hide(cancellationToken);
            _ = modesView.Hide(cancellationToken);
            return base.Hide(cancellationToken);
        }

    }
}