using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Views
{
    public interface ILoadingView : IWindow
    {
        void UpdateProgress(float? progress);
    }
}