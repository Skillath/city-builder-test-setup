using CityBuilder.Game.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Core.UseCases
{
    public class GameStartUseCase
    {
        private readonly GameStrategy gameStrategy;

        public GameStartUseCase(GameStrategy gameStrategy)
        {
            this.gameStrategy = gameStrategy;
        }

        public async Task PlayGame(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await gameStrategy.Load();
            await gameStrategy.PlayGame(cancellationToken);
            await gameStrategy.Unload();
        }
    }
}
