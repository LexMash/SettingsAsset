using SettingsAggregator.Implementation.Sounds;
using FMOD.Studio;

namespace SettingsAggregator.Sounds.Realisation.FMOD
{
    public class FMODSoundLayer : SoundLayerBase
    {
        private readonly VCA _vca;
        public FMODSoundLayer(VCA vca, SoundLayerData data) : base(data)
        {
            _vca = vca;

            StartVolumeInitialize();
        }

        protected override float GetDefaultValue()
        {
            _vca.getVolume(out float v);
            return v;
        }

        protected override void SetClampedValue(float value)
        {
            _vca.setVolume(value);
        }
    }
}
