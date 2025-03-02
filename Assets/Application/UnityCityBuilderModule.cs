using CityBuilder;
using CityBuilder.Core.Entities;
using CityBuilder.Data;
using CityBuilder.DataProvider;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Views;
using UnityCityBuilder.Core.Entities;
using UnityCityBuilder.DataProvider;
using UnityCityBuilder.Game.Buildings.Entities;
using UnityCityBuilder.Views;
using UnityEngine;
using Zenject;

namespace UnityCityBuilder
{
    [CreateAssetMenu(fileName = "UnityCityBuilderModule", menuName = "Installers/UnityCityBuilderModule")]
    public class UnityCityBuilderModule : ScriptableObjectInstaller<UnityCityBuilderModule>
    {
        [SerializeField]
        private LoadingView loadingView;

        [SerializeField]
        private GameView gameView;

        [Header("Buildings")]
        [SerializeField]
        private ResidenceBuilding residenceBuilding;
        [SerializeField]
        private WoodProductionBuilding woodProductionBuilding;
        [SerializeField]
        private SteelProductionBuilding steelProductionBuilding;

        public override void InstallBindings()
        {
            CityBuilderModule.Install(Container);

            Container.Bind<IGameLoader>().To<SceneGameLoader>().AsSingle();


           

            //Container.Bind<ILoader>().To<StreamingAssetsDataLoader>().AsSingle()
            //  .WhenInjectedInto(typeof(StreamingAssetsDataProvider<BuildingsData>), typeof(StreamingAssetsDataProvider<ResourcesData>));
            Container.Bind<ILoader>().To<ConvertibleScriptableObjectDataLoader>().AsSingle()
                .WhenInjectedInto(typeof(DataProvider<BuildingsData>), typeof(DataProvider<ResourcesData>));

            Container.BindIWindow<ILoadingView>().To<LoadingView>().FromComponentInNewPrefab(loadingView).AsSingle();
            Container.BindIWindow<IGameView>().To<GameView>().FromComponentInNewPrefab(gameView).AsSingle();

            var buildingsContainer = Container.CreateEmptyGameObject("BuildingsContainer");
            Container.BindMemoryPool<ResidenceBuilding, BuildingFactory>()
                .WithInitialSize(5)
                .ExpandByOneAtATime()
                .WithFactoryArguments(BuildingType.Residence)
                .FromComponentInNewPrefab(residenceBuilding)
                .UnderTransformGroup(buildingsContainer.name)
                .AsCached()
                .WhenInjectedInto<IBuildingLoader>();

            Container.BindMemoryPool<WoodProductionBuilding, BuildingFactory>()
                .WithInitialSize(5)
                .ExpandByOneAtATime()
                .WithFactoryArguments(BuildingType.WoodProductionBuilding)
                .FromComponentInNewPrefab(woodProductionBuilding)
                .UnderTransformGroup(buildingsContainer.name)
                .AsCached()
                .WhenInjectedInto<IBuildingLoader>();

            Container.BindMemoryPool<SteelProductionBuilding, BuildingFactory>()
                .WithInitialSize(5)
                .ExpandByOneAtATime()
                .WithFactoryArguments(BuildingType.SteelProductionBuilding)
                .FromComponentInNewPrefab(steelProductionBuilding)
                .UnderTransformGroup(buildingsContainer.name)
                .AsCached()
                .WhenInjectedInto<IBuildingLoader>();

            Container.Bind<IBuildingLoader>().To<BuildingLoader>().AsSingle();
        }
    }
}