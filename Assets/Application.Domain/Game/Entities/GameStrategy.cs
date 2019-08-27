using CityBuilder.Core.Entities;
using CityBuilder.Game.GameModes.Entities;
using CityBuilder.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Game.Entities
{
    public class GameStrategy
    {
        private readonly WindowNavigation windowNavigation;
        private readonly IGameLoader gameLoader;
        private readonly IList<IGameEndCondition> gameEndConditions;

        private IGameType currentGame;
        private GameModeSwitchHandler gameModeSwitchHandler;

        public GameStrategy(WindowNavigation windowNavigation, IGameLoader gameLoader, IList<IGameEndCondition> gameEndConditions)
        {
            this.windowNavigation = windowNavigation;
            this.gameLoader = gameLoader;
            this.gameEndConditions = gameEndConditions;
        }

        public async Task Load()
        {
            var loadingView = (ILoadingView)(await windowNavigation.Show<ILoadingView>(CancellationToken.None));
            loadingView.UpdateProgress(null);

            currentGame = await gameLoader.LoadGame(0, CancellationToken.None);
            _ = windowNavigation.Hide<ILoadingView>(CancellationToken.None);
        }

        public async Task PlayGame(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var gameUI = (IGameView)(await windowNavigation.Show<IGameView>(cancellationToken));
            gameModeSwitchHandler = new GameModeSwitchHandler(gameUI);
            _ = currentGame.Init(cancellationToken);

            gameModeSwitchHandler.Init(true);
            await Task.WhenAny(gameEndConditions.Select(gec => gec.WaitForGameEndCondition(cancellationToken)));
            gameModeSwitchHandler.Stop();

            await Task.WhenAll(windowNavigation.Hide<IGameView>(cancellationToken), currentGame.End(cancellationToken));
        }

        public async Task Unload()
        {
            await gameLoader.Unload();
            currentGame = null;
            gameModeSwitchHandler = null;
        }

    }
}
