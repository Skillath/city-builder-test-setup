using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Entities
{
    public interface IGameStrategy
    {
        Task Load(CancellationToken cancellationToken);

        Task Unload();
    }
}