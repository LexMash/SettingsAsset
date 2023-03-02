using SettingsAggregator.Graphics;

namespace SettingsAggregator.Implementation.View
{
    public sealed class WidgetQualityLevel : UIParameterSwitcherBase, IApplyable
    {
        public bool WasChanged => cachedQualityLevelIndex != qualityLevel.CurrentQualityLevelIndex;
        
        private int maxQualityLevelIndex => qualityLevel.QualityLevelsNames.Length - 1;
        private GraphicsQualityLevel qualityLevel;
        private int cachedQualityLevelIndex;

        public void Setup(GraphicsQualityLevel settings)
        {
            qualityLevel = settings;
            
            var index = qualityLevel.CurrentQualityLevelIndex;
            TextPanelSetup(qualityLevel.QualityLevelsNames[index]);
            
            cachedQualityLevelIndex = qualityLevel.CurrentQualityLevelIndex;
        }
        
        public void Apply()
        {
            qualityLevel.SetQualityLevel(cachedQualityLevelIndex);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (qualityLevel != null)
            {
                cachedQualityLevelIndex = qualityLevel.CurrentQualityLevelIndex;
            }
        }

        protected override void SetNextValue()
        {
            cachedQualityLevelIndex = GetClampedValue(cachedQualityLevelIndex + 1, maxQualityLevelIndex);

            TextPanelSetup(qualityLevel.QualityLevelsNames[cachedQualityLevelIndex]);
        }

        protected override void SetPreviousValue()
        {
            cachedQualityLevelIndex = GetClampedValue(cachedQualityLevelIndex - 1, maxQualityLevelIndex);

            TextPanelSetup(qualityLevel.QualityLevelsNames[cachedQualityLevelIndex]);
        }
    }
}
