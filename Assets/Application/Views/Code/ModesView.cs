using System.Threading;
using System.Threading.Tasks;
using CityBuilder.Views;
using UnityEngine;
using UnityEngine.UI;
using WorstGameStudios.Core.Engine.UI;

namespace UnityCityBuilder.Views
{
    public class ModesView : View, IModesView
    {
        public event ModesViewEventHander OnModeChanged;

        [SerializeField]
        private Button btnNormalMode;
        [SerializeField]
        private Button btnEditMode;

        private bool isInEditMode;

        public bool IsInEditMode
        {
            get => isInEditMode;
            set
            {

                if (isInEditMode != value)
                {
                    isInEditMode = value;

                    btnNormalMode.interactable = value;
                    btnEditMode.interactable = !value;

                    OnModeChanged?.Invoke(value);
                }
            }
        }



        public override async Task Show(CancellationToken cancellationToken)
        {
            await base.Show(cancellationToken);

            btnNormalMode.onClick.AddListener(() => IsInEditMode = false);
            btnEditMode.onClick.AddListener(() => IsInEditMode = true);
        }

        public override Task Hide(CancellationToken cancellationToken)
        {
            btnNormalMode.onClick.RemoveAllListeners();
            btnEditMode.onClick.RemoveAllListeners();

            return base.Hide(cancellationToken);
        }

    }
}
