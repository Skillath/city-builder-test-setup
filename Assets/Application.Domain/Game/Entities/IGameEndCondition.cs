using System.Threading;
using System.Threading.Tasks;

namespace CityBuilder.Game.Entities
{
    public interface IGameEndCondition
    {
        Task WaitForGameEndCondition(CancellationToken cancellationToken);
    }
}
