using System;
using UnityEngine;

namespace SettingsAggregator.Graphics
{
    public class ScreenMode : IScreenMode
    {
        public event Action OnChanged;
        public FullScreenMode Value => _data.ScreenMode;

        private ScreenSettingsData _data;     

        public ScreenMode(ScreenSettingsData data)
        {
            _data = data;
        }

        public void SetScreenMode(FullScreenMode screenMode)
        {
            Screen.SetResolution(_data.Width, _data.Height, screenMode);

            _data.ScreenMode = screenMode;

            OnChanged?.Invoke();
        }
    }
}
