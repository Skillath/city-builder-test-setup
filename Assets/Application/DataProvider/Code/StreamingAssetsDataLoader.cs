using CityBuilder.DataProvider;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace UnityCityBuilder.DataProvider
{
    public class StreamingAssetsDataLoader : ILoader
    {
        public async Task<TData> Load<TData>(string fileName)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

            var www = UnityWebRequest.Get(filePath);
            await www.SendWebRequest();
            var json = www.downloadHandler.text;

            return JsonConvert.DeserializeObject<TData>(json);
        }
    }
}
