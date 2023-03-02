namespace SettingsAggregator
{
    public interface ISettings : IChangeable
    {
        ISettingsElement[] Elements { get; }
    }
}
