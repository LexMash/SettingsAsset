using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.UI
{
    public class UISliderValueChanger : UIElementValueChangerBase
    {
        [SerializeField] private Slider _slider;
        [Range(0f, 5f)]
        [SerializeField] private float _step = 1f;

        public override void SetPrevValue()
        {
            if(ElementEnabled())
                Step(_slider.value - _step);
        }

        public override void SetNextValue()
        {
            if (ElementEnabled())
                Step(_slider.value + _step);
        }

        protected override bool ElementEnabled()
        {
            return _slider != null && _slider.enabled;
        }

        private void Step(float value)
        {
            _slider.value = value;
        }
    }
}
