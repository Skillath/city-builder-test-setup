using CityBuilder.Game.Buildings.Entities;
using DG.Tweening;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityCityBuilder.Game.Buildings.Entities
{
    public class DOTweenBuildingAnimator : MonoBehaviour, IBuildingAnimator
    {
        [SerializeField]
        private Transform modelContainer;

        private Tween currentTween;

        public void PlayIdleAnimation()
        {
            currentTween?.Kill();
            currentTween = modelContainer.DOShakeScale(1f).SetDelay(1f).SetLoops(-1);
        }

        public void PlaySelectAnimation()
        {
            currentTween?.Kill();
            currentTween = modelContainer.DOPunchScale(Vector3.up, 1f);
        }

        public async Task PlayShowAnimation(CancellationToken cancellationToken)
        {
            modelContainer.localScale = Vector3.zero;
            await modelContainer.DOScale(Vector3.one, 0.75f).DOAsync(cancellationToken);

        }
    }
}
