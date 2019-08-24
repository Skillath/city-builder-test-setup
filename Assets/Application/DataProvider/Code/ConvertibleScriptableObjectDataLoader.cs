using CityBuilder.Data;
using CityBuilder.DataProvider;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityCityBuilder.DataProvider
{
    public class ConvertibleScriptableObjectDataLoader : ILoader
    {
        public async Task<TData> Load<TData>(string fileName)
        {
            var loadTask = Resources.LoadAsync(fileName, typeof(IConvertible<TData>));
            await loadTask.ToTask();
            if (!loadTask.isDone)
            {
                throw new System.Exception($"Couldn't load {fileName}");
            }

            if (loadTask.asset is IConvertible<TData> data)
            {
                var loadedData = data.ToData();
                Resources.UnloadAsset(loadTask.asset);
                return loadedData;

            }
            throw new System.Exception($"Couldn't load {fileName}");
        }
    }
}
