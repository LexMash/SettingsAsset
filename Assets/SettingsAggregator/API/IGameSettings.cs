namespace SettingsAggregator
{
    public interface IGameSettings : IChangeable
    {
        ISettings[] Settings { get; }
    }
}