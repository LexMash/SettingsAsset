using SettingsAggregator.Graphics;
using SettingsAggregator.Implementation.Sounds;
using System;

namespace SettingsAggregator
{
    [Serializable]
    public class GameSettingsData
    {
        public GraphicsQualityLevelData QualityLevelData;
        public ScreenSettingsData ScreenSettingsData;
        public SoundLayerData[] SoundLayerData;
    }
}
