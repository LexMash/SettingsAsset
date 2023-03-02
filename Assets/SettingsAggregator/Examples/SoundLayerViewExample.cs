using SettingsAggregator.Implementation.Sounds;
using SettingsAggregator.Implementation.View;
using SettingsAggregator.Sounds.Realisation.Unity;
using UnityEngine;
using UnityEngine.Audio;

namespace SettingsAggregator.Examples
{
    public class SoundLayerViewExample : SoundLayerViewBase
    {
        [SerializeField] private AudioMixerGroup _group;
        [SerializeField] private string _name;
        [Range(-80, 0)]
        [SerializeField] private float _cashedVolume = 0;
        [SerializeField] private bool _isEnable = true;

        protected override ISoundLayer GetLayer(SoundLayerCategory category)
        {
            var data = new SoundLayerData(category, _cashedVolume, _isEnable, _cashedVolume);

            return new UnitySoundLayer(_group, data, _name);
        }
    }
}
