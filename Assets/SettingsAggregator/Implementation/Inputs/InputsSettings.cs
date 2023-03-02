using SettingsAggregator.Implementation;

namespace SettingsAggregator.Inputs
{
    public class InputsSettings : SettingsBase<IInputsSettingsElement>, ISettings
    {
        public ISettingsElement[] Elements => _elements;

        public InputsSettings(params IInputsSettingsElement[] settings) : base(settings)
        {
        }
    }
}