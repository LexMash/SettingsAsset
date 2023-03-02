using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.Implementation.View
{
    public abstract class UIParameterToggleBase : MonoBehaviour
    {
        [SerializeField] protected Toggle _toggle;

        protected virtual void Awake()
        {
            if (!_toggle)
                Debug.LogWarning($"{gameObject.name} don`t have toggle");
            else
                ToggleSetup();
        }

        protected virtual void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        protected virtual void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        protected abstract void ToggleSetup();
        protected abstract void OnValueChanged(bool value);
    }
}
