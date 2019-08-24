using WorstGameStudios.Core.Abstractions.Engine.UI;
using WorstGameStudios.Core.Abstractions.Engine.Logger;
using WorstGameStudios.Core.Abstractions.Engine.Core;
using System.Threading.Tasks;

namespace CityBuilder.Core.Entities
{
    public class App
    {
        private readonly IApplicationQuitter applicationQuitter;
        private readonly WindowNavigation windowNavigation;
        private readonly IRoot root;
        private readonly AppInitializer appInitializer;

        public App(IApplicationQuitter applicationQuitter, WindowNavigation windowNavigation, IRoot root, AppInitializer appInitializer)
        {
            this.applicationQuitter = applicationQuitter;
            this.windowNavigation = windowNavigation;
            this.root = root;
            this.appInitializer = appInitializer;


            applicationQuitter.OnQuit += ApplicationQuitter_OnQuit;
            this.root.OnInitialized += Root_OnInitialized;

            InitAndLoad();
        }

        private async void InitAndLoad()
        {
            await Load();
        }

        private Task Load()
        {
            return Task.CompletedTask;
        }

        private Task ApplicationQuitter_OnQuit()
        {
            applicationQuitter.OnQuit -= ApplicationQuitter_OnQuit;

            return Task.CompletedTask;
        }

        private void Root_OnInitialized()
        {
            root.OnInitialized -= Root_OnInitialized;
            appInitializer.SetInitialized();

            //SHOW LOADING WINDOW

            //LOAD GAME

            //SHOW GAME UI

            //HIDE LOADING WINDOW

        }


    }
}