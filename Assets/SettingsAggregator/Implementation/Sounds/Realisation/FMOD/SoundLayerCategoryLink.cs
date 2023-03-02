using System;
using UnityEngine;

namespace SettingsAggregator.Implementation.Sounds.Realisation
{
    /// <summary>
    /// привязываем имя Vca или AudioMixer к категории нашего звукового слоя
    /// </summary>
    [Serializable]
    public class SoundLayerCategoryLink
    {
        [SerializeField] private SoundLayerCategory _category;
        [SerializeField] private string _name;

        public SoundLayerCategory Category => _category;
        public string Name => _name;
    }
}
