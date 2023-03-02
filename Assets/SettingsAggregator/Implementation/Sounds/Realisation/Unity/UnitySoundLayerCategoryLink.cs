using System;
using UnityEngine;
using UnityEngine.Audio;

namespace SettingsAggregator.Implementation.Sounds.Realisation
{
    [Serializable]
    public class UnitySoundLayerCategoryLink : SoundLayerCategoryLink
    {
        [SerializeField] private AudioMixerGroup _mixer;
        public AudioMixerGroup Mixer => _mixer;
    }
}
