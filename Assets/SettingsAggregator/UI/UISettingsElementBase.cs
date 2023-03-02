using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SettingsAggregator.UI
{
    public class UISettingsElementBase : Selectable
    {
        [SerializeField] private UIElementValueChangerBase _changer;
        public UIElementValueChangerBase Changer => _changer;

        public event Action<UISettingsElementBase> Selected;
        public event Action<UISettingsElementBase> Deselected;

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);

            Selected?.Invoke(this);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);

            Deselected?.Invoke(this);
        }
    }
}
