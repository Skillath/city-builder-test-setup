using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Buildings.Entities
{
    public interface IBuildingAnimator
    {
        Task PlayShowAnimation(CancellationToken cancellationToken);

        void PlayIdleAnimation();

        void PlaySelectAnimation();
    }
}
