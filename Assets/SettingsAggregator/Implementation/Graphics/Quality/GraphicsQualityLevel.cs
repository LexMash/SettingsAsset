using System;
using UnityEngine;

namespace SettingsAggregator.Graphics
{
    public class GraphicsQualityLevel : IGraphicsSettingsElement
    {
        public event Action OnChanged;
        public int CurrentQualityLevelIndex => _data.CurrentQualityLevelIndex;
        public string[] QualityLevelsNames => QualitySettings.names;

        private readonly GraphicsQualityLevelData _data;

        public GraphicsQualityLevel(GraphicsQualityLevelData data)
        {
            _data = data;

            QualitySettings.SetQualityLevel(CurrentQualityLevelIndex, true);
        }

        public void SetQualityLevel(int index)
        {
            QualitySettings.SetQualityLevel(index, true);

            _data.CurrentQualityLevelIndex = index;

            OnChanged?.Invoke();
        }
    }
}
