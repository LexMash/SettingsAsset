using System;

namespace SettingsAggregator.Implementation.Sounds
{
    [Serializable]
    public class SoundLayerData
    {
        public SoundLayerCategory Category;
        public float CurrentVolume;
        public float CashedValue;
        public bool IsEnable;
        public float MaxVolume;
        public float MinVolume;        

        public SoundLayerData(SoundLayerCategory category, float cashedValue, bool isEnable, float currentVolume = -100f, float maxVolume = 0f, float minVolume = -80f)
        {
            Category = category;
            CurrentVolume = currentVolume;
            CashedValue = cashedValue;
            IsEnable = isEnable;

            MaxVolume = maxVolume;
            MinVolume = minVolume;       
        }
    }
}
