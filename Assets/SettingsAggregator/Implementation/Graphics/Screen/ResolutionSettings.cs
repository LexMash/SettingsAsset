using System;
using System.Linq;
using UnityEngine;

namespace SettingsAggregator.Graphics
{
    public class ResolutionSettings : IResolutionSettings
    {
        public event Action OnChanged;
        public int Width => _data.Width;
        public int Height => _data.Height;
        public Resolution[] AvailableResolutions { get; private set; }
        public Resolution CurrentResolution => Screen.currentResolution;

        private ScreenSettingsData _data;       

        public ResolutionSettings(ScreenSettingsData data)
        {
            _data = data;
            AvailableResolutions = GetResolutionsWithoutDoubles();

            //нужно ли тут сразу задавать разрешение?
            //если нет, то где?
            //SetScreenResolution(_data.Width, _data.Height);
        }

        public void SetScreenResolution(int width, int height)
        {
            Screen.SetResolution(width, height, _data.ScreenMode, _data.RefreshRate);

            _data.Width = width;
            _data.Height = height;

            OnChanged?.Invoke();
        }

        private Resolution[] GetResolutionsWithoutDoubles()
        {
            var maxRate = Screen.resolutions.Max(r => r.refreshRate);

            return Screen.resolutions.
                Where(r => r.refreshRate == maxRate).
                Cast<Resolution>().ToArray();
        }
    }
}
