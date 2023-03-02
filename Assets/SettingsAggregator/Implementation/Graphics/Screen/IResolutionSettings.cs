namespace SettingsAggregator.Graphics
{
    public interface IResolutionSettings : IGraphicsSettingsElement
    {
        int Width { get; }
        int Height { get; }
    }
}
