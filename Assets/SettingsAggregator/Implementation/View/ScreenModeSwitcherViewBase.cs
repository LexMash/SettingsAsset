using SettingsAggregator.Graphics;
using System;
using UnityEngine;

namespace SettingsAggregator.Implementation.View
{
    public abstract class ScreenModeSwitcherViewBase : UIParameterSwitcherBase
    {
        private int maxValue => Enum.GetValues(typeof(FullScreenMode)).Length - 1;

        private ScreenMode _screenMode;

        protected virtual void Awake()
        {
            _screenMode = GetScreenMode();

            TextPanelSetup(_screenMode.Value.ToString());
        }

        protected override void SetNextValue()
        {
            var currentIndex = GetCurrentScreenIndex();
            var newIndex = GetClampedValue(currentIndex + 1, maxValue);
            var mode = (FullScreenMode)newIndex;

            TextPanelSetup(mode.ToString());
            _screenMode.SetScreenMode(mode);
        }

        protected override void SetPreviousValue()
        {
            var currentIndex = GetCurrentScreenIndex();
            var newIndex = GetClampedValue(currentIndex - 1, maxValue);
            var mode = (FullScreenMode)newIndex;

            TextPanelSetup(mode.ToString());
            _screenMode.SetScreenMode(mode);
        }

        protected int GetCurrentScreenIndex()
        {
            return (int)_screenMode.Value;
        }

        protected abstract ScreenMode GetScreenMode();
    }
}
