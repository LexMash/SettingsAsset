using System;
using SettingsAggregator.Graphics;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace SettingsAggregator.Examples
{
    [Serializable]
    public class GameSettingsData
    {
        public GraphicsQualityLevelData GraphicsQualityLevelData;
        public ScreenSettingsData ScreenSettingsData;

        public static GameSettingsData Default => GetDefault();

        private static GameSettingsData GetDefault()
        {
            var settings = new GameSettingsData();
            
            settings.GraphicsQualityLevelData = new GraphicsQualityLevelData
            {
                CurrentQualityLevelIndex = 1
            };
            
            settings.ScreenSettingsData = new ScreenSettingsData
            {
                Height = Screen.height,
                RefreshRate = 0,
                ScreenMode = FullScreenMode.ExclusiveFullScreen,
                Width = Screen.width
            };

            return settings;
        }
    }
}