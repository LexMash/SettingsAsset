using UnityEngine;

namespace SettingsAggregator.Graphics
{
    public interface IScreenMode : IGraphicsSettingsElement
    {
        FullScreenMode Value { get; }
    }
}
