using SettingsAggregator.Graphics;
using UnityEngine;

namespace SettingsAggregator.Implementation.View
{
    public sealed class WidgetScreenModeToggle : UIParameterToggleBase
    {
        [SerializeField] private FullScreenMode _fullScreenMode = FullScreenMode.FullScreenWindow;
        [SerializeField] private FullScreenMode _nonFullScreenMode = FullScreenMode.Windowed;

        private ScreenMode screenMode;

        public void Setup(ScreenMode screenMode)
        {
            this.screenMode = screenMode;
            
            ToggleSetup();
        }

        protected override void OnValueChanged(bool value)
        {
            FullScreenMode mode = value == true ? _fullScreenMode : _nonFullScreenMode;

            screenMode.SetScreenMode(mode);
        }

        protected override void ToggleSetup()
        {
            if (screenMode != null)
            {
                _toggle.isOn = screenMode.Value == _fullScreenMode;
            }
        }
    }
}
