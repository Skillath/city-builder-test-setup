using CityBuilder.Core.Entities;
using CityBuilder.Core.UseCases;
using CityBuilder.Game.Player.Entities;
using Zenject;

namespace CityBuilder
{
    public class CityBuilderModule : Installer<CityBuilderModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<App>().AsSingle();
            Container.Bind<Player>().AsSingle();
            Container.Bind<ResourcesExchanger>().AsSingle();

            Container.Bind<GameStartUseCase>().AsSingle();
        }
    }
}