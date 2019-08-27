using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Views
{
    public delegate void ModesViewEventHander(bool editMode);
    public interface IModesView : IWindow
    {
        event ModesViewEventHander OnModeChanged;

        bool IsInEditMode { get; set; }
    }
}
