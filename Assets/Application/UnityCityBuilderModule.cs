using CityBuilder;
using CityBuilder.Data;
using CityBuilder.DataProvider;
using CityBuilder.Game.Buildings.Entities;
using CityBuilder.Views;
using UnityCityBuilder.Data.Entities;
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

        [Space]
        [Header("Buildings")]
        [SerializeField]
        private ResidenceBuilding residenceBuilding;


        public override void InstallBindings()
        {
            CityBuilderModule.Install(Container);


            Container.Bind<DataProvider<BuildingsData>>().AsSingle().WithArguments("BuildingsData");
            Container.Bind<DataProvider<ResourcesData>>().AsSingle().WithArguments("ResourcesData");

            //Container.Bind<ILoader>().To<StreamingAssetsDataLoader>().AsSingle()
            //  .WhenInjectedInto(typeof(StreamingAssetsDataProvider<BuildingsData>), typeof(StreamingAssetsDataProvider<ResourcesData>));
            Container.Bind<ILoader>().To<ConvertibleScriptableObjectDataLoader>().AsSingle()
                .WhenInjectedInto(typeof(DataProvider<BuildingsData>), typeof(DataProvider<ResourcesData>));

            Container.BindIWindow<ILoadingView>().To<LoadingView>().FromComponentInNewPrefab(loadingView).AsSingle();

            var buildingsContainer = Container.CreateEmptyGameObject("BuildingsContainer");
            Container.BindMemoryPool<ResidenceBuilding, BuildingFactory>()
                .WithInitialSize(5)
                .ExpandByOneAtATime()
                .WithFactoryArguments(BuildingType.Residence)
                .FromComponentInNewPrefab(residenceBuilding)
                .UnderTransformGroup(buildingsContainer.name)
                .AsCached()
                .WhenInjectedInto<IBuildingLoader>();

            Container.Bind<IBuildingLoader>().To<BuildingLoader>().AsSingle();
        }
    }
}