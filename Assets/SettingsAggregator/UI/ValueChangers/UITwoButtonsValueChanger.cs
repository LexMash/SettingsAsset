using System;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.UI
{
    public class UITwoButtonsValueChanger : UIElementValueChangerBase
    {
        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonPrev;

        private void Awake()
        {
            if (!ElementEnabled())
                throw new NullReferenceException($"{gameObject.name} don`t have any buttons");
        }

        public override void SetPrevValue()
        {
            _buttonPrev.onClick.Invoke();
        }

        public override void SetNextValue()
        {
            _buttonNext.onClick.Invoke();
        }

        protected override bool ElementEnabled()
        {
            return _buttonNext.enabled && _buttonPrev.enabled && _buttonPrev != null && _buttonNext != null;
        }
    }
}
