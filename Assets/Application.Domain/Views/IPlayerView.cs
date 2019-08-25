using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Views
{
    public interface IPlayerView : IWindow
    {
        void Initialize();

        void Stop();
    }
}
