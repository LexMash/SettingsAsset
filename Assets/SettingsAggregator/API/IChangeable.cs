using System;

namespace SettingsAggregator
{
    public interface IChangeable
    {
        event Action OnChanged;
    }
}
