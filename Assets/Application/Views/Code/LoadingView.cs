﻿using CityBuilder.Views;
using UnityEngine;
using UnityEngine.UI;
using WorstGameStudios.Core.Engine.UI;

namespace UnityCityBuilder.Views
{
    public class LoadingView : View, ILoadingView
    {
        [SerializeField]
        private Slider slider;

        public void UpdateProgress(float? progress)
        {
            slider.gameObject.SetActive(progress.HasValue);
            slider.value = Mathf.Clamp01(progress ?? 0);
        }
    }
}