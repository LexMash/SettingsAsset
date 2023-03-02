using SettingsAggregator;

namespace Glifs
{
    public interface IGlifsFeature : IChangeable
    {
        public GlifsScheme CurrentGlifsScheme { get; }
    }
}
