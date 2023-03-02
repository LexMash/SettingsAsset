using FMODUnity;
using SettingsAggregator.Sounds.Realisation.FMOD;
using System.Linq;
using FMOD.Studio;

namespace SettingsAggregator.Implementation.Sounds.Realisation.FMOD
{
    //это просто мысли на тему сборщика для FMOD
    public static class FMODSoundLayersLoader
    {
        public static ISoundLayer[] SoundLayersFromScheme(SoundLayersScheme scheme, SoundLayerData[] datas = null)
        {
            ISoundLayer[] soundLayers = new ISoundLayer[scheme.Links.Length]; 

            for(int i = 0; i < soundLayers.Length; i++)
            {
                string path = scheme.Links[i].Name;
                SoundLayerCategory category = scheme.Links[i].Category;
                VCA vca = RuntimeManager.GetVCA(path);

                SoundLayerData data;

                if (datas != null)
                    data = datas.First(d => d.Category == category);
                else
                    data = CreateSoundData(vca, category);

                ISoundLayer soundLayer = new FMODSoundLayer(vca, data);
                soundLayers[i] = soundLayer;
            }

            return soundLayers;
        }

        //А сохраним потом из массива слоёв!
        private static SoundLayerData CreateSoundData(VCA vca, SoundLayerCategory category)
        {
            float volume;
            vca.getVolume(out volume);
            return new SoundLayerData(category, volume, true, volume);
        }
    }
}
