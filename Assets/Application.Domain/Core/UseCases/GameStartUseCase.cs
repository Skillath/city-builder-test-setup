using CityBuilder.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace CityBuilder.Core.UseCases
{
    public class GameStartUseCase
    {
        private readonly WindowNavigation windowNavigation;
        private readonly IGameLoader gameLoader;

        public GameStartUseCase(WindowNavigation windowNavigation, IGameLoader gameLoader)
        {
            this.windowNavigation = windowNavigation;
            this.gameLoader = gameLoader;
        }

        public async Task PlayGame(CancellationToken cancellationToken)
        {

        }

        private async Task LaunchGame(CancellationToken cancellationToken)
        {

        }
    }
}
