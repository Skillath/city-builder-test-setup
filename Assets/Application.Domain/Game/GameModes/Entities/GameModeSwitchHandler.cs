using CityBuilder.Views;

namespace CityBuilder.Game.GameModes.Entities
{
    public class GameModeSwitchHandler
    {
        private readonly IGameView gameView;

        private IGameMode normalMode;
        private IGameMode editMode;

        public IGameMode CurrentGameMode { get; private set; }

        public GameModeSwitchHandler(IGameView gameView)
        {
            this.gameView = gameView;
        }

        public void Init(bool startInEditMode = false)
        {
            gameView.ModesView.IsInEditMode = startInEditMode;
            gameView.ModesView.OnModeChanged += ModesView_OnModeChanged;
            ModesView_OnModeChanged(startInEditMode);
        }

        private void ModesView_OnModeChanged(bool isInEditMode)
        {
            CurrentGameMode?.StopGameMode();
            CurrentGameMode = isInEditMode ? editMode : normalMode;
            CurrentGameMode?.InitGameMode();
        }

        public void Stop()
        {
            gameView.ModesView.OnModeChanged -= ModesView_OnModeChanged;
        }
    }
}
