using SettingsAggregator.Implementation.Sounds;
using UnityEngine.Audio;

namespace SettingsAggregator.Sounds.Realisation.Unity
{
    //конкретная реализация под юнити
    public class UnitySoundLayer : SoundLayerBase
    {
        //пока непонятно что лучше использовать group или audioMixer - надо проверять в работе
        private readonly AudioMixerGroup _audioGroup;
        private readonly string _name;

        public UnitySoundLayer(AudioMixerGroup audioGroup, SoundLayerData data, string name) : base(data)
        {
            _name = name;
            _audioGroup = audioGroup;

            StartVolumeInitialize();
        }

        protected override float GetDefaultValue()
        {
            _audioGroup.audioMixer.GetFloat(_name, out float v);
            return v;
        }

        protected override void SetClampedValue(float value)
        {
            _audioGroup.audioMixer.SetFloat(_name, CurrentVolume);
        }
    }
}
