using CityBuilder.Core.Entities;
using CityBuilder.Core.UseCases;
using CityBuilder.Data;
using CityBuilder.DataProvider;
using CityBuilder.Game.Entities;
using CityBuilder.Game.Player.Entities;
using Zenject;

namespace CityBuilder
{
    public class CityBuilderModule : Installer<CityBuilderModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<App>().AsSingle();
            Container.Bind<AppDataLoader>().AsSingle();
            Container.Bind<Player>().AsSingle();
            Container.Bind<ResourcesExchanger>().AsSingle();

            Container.Bind<GameStartUseCase>().AsSingle();
            Container.Bind<GameStrategy>().AsSingle();

            Container.Bind<DataProvider<BuildingsData>>().AsSingle().WithArguments("BuildingsData");
            Container.Bind<DataProvider<ResourcesData>>().AsSingle().WithArguments("ResourcesData");

            Container.Bind<IGameEndCondition>().To<GameWinCondition>().AsCached();
        }
    }
}