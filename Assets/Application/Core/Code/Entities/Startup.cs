using CityBuilder.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UnityCityBuilder.Core.Entities
{
    public class Startup : MonoBehaviour
    {
        [Inject]
        private void Inject(App app) => _ = app;
    }
}