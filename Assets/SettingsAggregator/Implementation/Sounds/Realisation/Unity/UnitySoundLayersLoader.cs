using SettingsAggregator.Sounds.Realisation.Unity;
using System.Linq;
using UnityEngine.Audio;

namespace SettingsAggregator.Implementation.Sounds.Realisation.Unity
{
    public static class UnitySoundLayersLoader
    {
        public static ISoundLayer[] SoundLayersFromScheme(UnitySoundLayersScheme scheme, SoundLayerData[] datas = null)
        {
            ISoundLayer[] soundLayers = new ISoundLayer[scheme.Links.Length];

            for (int i = 0; i < soundLayers.Length; i++)
            {
                string name = scheme.Links[i].Name;
                SoundLayerCategory category = scheme.Links[i].Category;
                AudioMixerGroup mixer = scheme.Links[i].Mixer;

                SoundLayerData data;

                if (datas != null)
                    data = datas.First(d => d.Category == category);
                else
                    data = CreateSoundData(mixer, category, name);

                ISoundLayer soundLayer = new UnitySoundLayer(mixer, data, name);
                soundLayers[i] = soundLayer;
            }

            return soundLayers;
        }

        private static SoundLayerData CreateSoundData(AudioMixerGroup mixer, SoundLayerCategory category, string name)
        {
            float volume;
            mixer.audioMixer.GetFloat(name, out volume);
            return new SoundLayerData(category, volume, true, volume);
        }
    }
}
