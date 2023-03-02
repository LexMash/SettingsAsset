using UnityEngine;

namespace SettingsAggregator.UI
{
    public abstract class UIElementValueChangerBase : MonoBehaviour
    {
        public abstract void SetNextValue();
        public abstract void SetPrevValue();
        protected abstract bool ElementEnabled();
    }
}
