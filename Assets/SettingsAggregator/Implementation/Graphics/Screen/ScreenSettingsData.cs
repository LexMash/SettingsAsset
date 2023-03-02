using System;
using UnityEngine;

namespace SettingsAggregator.Graphics
{
    [Serializable]
    public class ScreenSettingsData
    {
        public int Width;
        public int Height;
        public int RefreshRate;
        public FullScreenMode ScreenMode;
    }
}
