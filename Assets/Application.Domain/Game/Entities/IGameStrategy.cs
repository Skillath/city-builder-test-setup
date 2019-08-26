using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Entities
{
    public interface IGameType
    {
        Task Load(CancellationToken cancellationToken);

        Task Unload();
    }
}