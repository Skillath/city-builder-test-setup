using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Views
{
    public interface IGameView : IWindow
    {
        IPlayerView PlayerView { get; }
    }
}