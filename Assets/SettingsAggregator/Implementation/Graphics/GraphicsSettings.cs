using SettingsAggregator.Implementation;

namespace SettingsAggregator.Graphics
{
    public class GraphicsSettings : SettingsBase<IGraphicsSettingsElement>, ISettings
    {
        public ISettingsElement[] Elements => _elements;
        public GraphicsSettings(params IGraphicsSettingsElement[] settings) : base(settings)
        {
        }        
    }
}
