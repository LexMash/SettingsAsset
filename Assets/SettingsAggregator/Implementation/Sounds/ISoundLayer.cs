namespace SettingsAggregator.Implementation.Sounds
{
    public interface ISoundLayer : ISoundsSettingsElement
    {
        SoundLayerCategory Category { get; }
        float CurrentVolume { get; }
        float CashedValue { get; }
        float MaxVolume { get; }
        float MinVolume { get; }
        bool IsEnable { get; }

        public void SetVolume(float volume);
        public void Enable(bool enable);
    }
}
