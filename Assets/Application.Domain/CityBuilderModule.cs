using CityBuilder.Core.Entities;
using UnityEngine;
using Zenject;

namespace CityBuilder
{
    public class CityBuilderModule : Installer<CityBuilderModule>
    {
        public override void InstallBindings()
        {
            Container.Bind<App>().AsSingle();
        }
    }
}