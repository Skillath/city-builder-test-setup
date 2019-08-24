using CityBuilder.DataProvider;
using System.Threading.Tasks;

namespace CityBuilder.DataProvider
{
    public class DataProvider<TData>
    {
        private readonly ILoader loader;
        private readonly string relativePath;

        public TData Data { get; private set; }

        public DataProvider(ILoader loader, string relativePath)
        {
            this.loader = loader;
            this.relativePath = relativePath;
        }

        public async Task<TData> GetData()
        {
            if (this.Data == null)
            {
                this.Data = await loader.Load<TData>(relativePath);
            }

            return this.Data;
        }
    }
}
