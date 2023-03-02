using SettingsAggregator.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SettingsAggregator.UI
{
    public class UIToggleValueChanger : UIElementValueChangerBase
    {
        [SerializeField] private Toggle _toggle;

        private void Awake()
        {
            if (!ElementEnabled())
                throw new NullReferenceException($"{gameObject.name} don`t have toggle");
        }

        public override void SetPrevValue()
        {
                _toggle.isOn = false;
        }

        public override void SetNextValue()
        {
                _toggle.isOn = true;
        }

        protected override bool ElementEnabled()
        {
            return _toggle != null && _toggle.enabled;
        }
    }
}
