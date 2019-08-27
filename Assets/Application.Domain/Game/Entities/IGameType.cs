using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Entities
{
    public interface IGameType
    {
        Task Init(CancellationToken cancellationToken);

        Task End(CancellationToken canellationToken);
    }
}