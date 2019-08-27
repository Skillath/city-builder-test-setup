using CityBuilder.Data;
using CityBuilder.Game.Player.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace CityBuilder.Game.Entities
{
    public class GameWinCondition : IGameEndCondition
    {
        private readonly ResourcesExchanger exchanger;
        private readonly Player.Entities.Player player;

        private TaskCompletionSource<bool> tcs;
        private int maxResources = 100000;

        public GameWinCondition(ResourcesExchanger exchanger, Player.Entities.Player player)
        {
            this.exchanger = exchanger;
            this.player = player;
        }

        public async Task WaitForGameEndCondition(CancellationToken cancellationToken)
        {
            tcs = new TaskCompletionSource<bool>();

            void onResourceAdded(ResourceType resourceType, int quantity)
            {
                if (MaxReached())
                {
                    tcs?.SetResult(true);
                }
            }

            var cancellation = cancellationToken.Register(() => tcs?.SetResult(false));
            exchanger.OnResourceAdded += onResourceAdded;
            await tcs.Task;
            exchanger.OnResourceAdded -= onResourceAdded;
            tcs = null;
            cancellation.Dispose();
        }

        private bool MaxReached()
        {
            foreach (var resourceData in player.Resources.Values)
            {
                if (resourceData < maxResources)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
