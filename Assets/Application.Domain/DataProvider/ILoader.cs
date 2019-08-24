using System.Threading.Tasks;

namespace CityBuilder.DataProvider
{
    public interface ILoader
    {
        Task<TData> Load<TData>(string fileName);
    }
}
