using WorstGameStudios.Core.Abstractions.Engine.UI;
using WorstGameStudios.Core.Abstractions.Engine.Logger;
using WorstGameStudios.Core.Abstractions.Engine.Core;
using System.Threading.Tasks;
using CityBuilder.Core.UseCases;
using System.Threading;
using CityBuilder.Data;

namespace CityBuilder.Core.Entities
{
    public class App
    {
        private readonly IApplicationQuitter applicationQuitter;
        private readonly IRoot root;
        private readonly AppInitializer appInitializer;
        private readonly GameStartUseCase gameStartUseCase;
        private readonly AppDataLoader appDataLoader;

        private CancellationTokenSource gameCancellationTokenSource;

        public App(IApplicationQuitter applicationQuitter, IRoot root, AppInitializer appInitializer, GameStartUseCase gameStartUseCase, AppDataLoader appDataLoader)
        {
            this.applicationQuitter = applicationQuitter;
            this.root = root;
            this.appInitializer = appInitializer;
            this.gameStartUseCase = gameStartUseCase;
            this.appDataLoader = appDataLoader;

            applicationQuitter.OnQuit += ApplicationQuitter_OnQuit;
            this.root.OnInitialized += Root_OnInitialized;
        }

        private Task Load() => appDataLoader.LoadAppData();

        private Task ApplicationQuitter_OnQuit()
        {
            applicationQuitter.OnQuit -= ApplicationQuitter_OnQuit;

            gameCancellationTokenSource?.Cancel();
            gameCancellationTokenSource = null;

            return Task.CompletedTask;
        }

        private async void Root_OnInitialized()
        {
            root.OnInitialized -= Root_OnInitialized;
            await Load();
            appInitializer.SetInitialized();

            gameCancellationTokenSource = new CancellationTokenSource();

            try
            {
                await gameStartUseCase.PlayGame(gameCancellationTokenSource.Token);
            }
            catch (TaskCanceledException) { }
        }
    }
}