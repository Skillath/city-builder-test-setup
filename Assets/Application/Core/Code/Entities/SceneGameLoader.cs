using CityBuilder.Core.Entities;
using CityBuilder.Game.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using Zenject;

namespace UnityCityBuilder.Core.Entities
{
    public class SceneGameLoader : IGameLoader
    {
        private readonly ZenjectSceneLoader sceneLoader;

        private Scene? currentScene = null;

        public SceneGameLoader(ZenjectSceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public async Task<IGameStrategy> LoadGame(int buildIndex, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<IGameStrategy>();
            void onSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                if (tcs.Task.IsCompleted || tcs.Task.IsCanceled || tcs.Task.IsFaulted)
                {
                    return;
                }

                if (scene.buildIndex == buildIndex)
                {
                    currentScene = scene;
                    SceneManager.SetActiveScene(scene);
                    var gameType = scene.GetRootGameObjects().FirstOrDefault().GetComponent<IGameStrategy>();
                    tcs.SetResult(gameType);
                }
            }

            SceneManager.sceneLoaded += onSceneLoaded;
            _ = sceneLoader.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
            await tcs.Task;
            SceneManager.sceneLoaded -= onSceneLoaded;

            if (tcs.Task.IsCompleted && !tcs.Task.IsCanceled && !tcs.Task.IsFaulted)
            {
                return tcs.Task.Result;
            }

            tcs = null;
            return null;
        }

        public async Task Unload()
        {
            if (!currentScene.HasValue)
            {
                return;
            }

            await SceneManager.UnloadSceneAsync(currentScene.Value);
            currentScene = null;
        }
    }
}
