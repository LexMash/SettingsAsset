namespace SettingsAggregator
{
    public interface IApplyable
    {
        bool WasChanged { get; }
        void Apply();
    }
}
