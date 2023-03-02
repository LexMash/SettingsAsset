using SettingsAggregator.Graphics;
using UnityEngine;

namespace SettingsAggregator.Implementation.View
{
    public sealed class WidgetScreenResolutions : UIParameterSwitcherBase, IApplyable 
    {
        public bool WasChanged { get; private set; }

        private int maxIndex => resolutionSettings.AvailableResolutions.Length - 1;
        private string resolutionString => $"{cashedResolution.width} x {cashedResolution.height}";
        private ResolutionSettings resolutionSettings;
        private Resolution cashedResolution;

        public void Setup(ResolutionSettings settings)
        {
            resolutionSettings = settings;
            cashedResolution = resolutionSettings.CurrentResolution;
            TextPanelSetup(resolutionString);
        }
        
        public void Apply()
        {
            resolutionSettings.SetScreenResolution(cashedResolution.width, cashedResolution.height);
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();

            WasChanged = false;
            
            if (resolutionSettings != null)
            {
                cashedResolution = resolutionSettings.CurrentResolution;
            }
        }

        protected override void SetNextValue()
        {
            WasChanged = true;

            var currentIndex = GetCurrentResolutionIndex();
            var nextIndex = GetClampedValue(currentIndex + 1, maxIndex);
            cashedResolution = resolutionSettings.AvailableResolutions[nextIndex];

            TextPanelSetup(resolutionString);
        }

        protected override void SetPreviousValue()
        {
            WasChanged = true;

            var currentIndex = GetCurrentResolutionIndex();
            var nextIndex = GetClampedValue(currentIndex - 1, maxIndex);
            cashedResolution = resolutionSettings.AvailableResolutions[nextIndex];

            TextPanelSetup(resolutionString);
        }

        private int GetCurrentResolutionIndex()
        {
            var resolutions = resolutionSettings.AvailableResolutions;

            for (int i = 0; i < resolutions.Length; i++)
                if (resolutions[i].height == cashedResolution.height && 
                    resolutions[i].width == cashedResolution.width) //хочется перегрузить оператор == и != для Resolution
                    return i;

            return resolutions.Length - 1; //или лучше экспешн?..
        }
    }
}