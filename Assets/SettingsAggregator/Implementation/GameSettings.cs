namespace SettingsAggregator.Implementation
{
    public class GameSettings : SettingsBase<ISettings>, IGameSettings
    {
        public ISettings[] Settings => _elements;

        public GameSettings(params ISettings[] settings) : base(settings) { }
    }
}
