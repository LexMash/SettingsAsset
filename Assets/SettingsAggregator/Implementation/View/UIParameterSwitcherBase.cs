using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.Implementation.View
{
    public abstract class UIParameterSwitcherBase : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _valueTxt;
        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonPrev;
        [SerializeField] private bool _circleSwitch = true;

        protected virtual void OnEnable()
        {
            if (!_buttonNext || !_buttonPrev)
                Debug.LogWarning($"{gameObject.name} don`t have buttons");

            _buttonNext.onClick.AddListener(SetNextValue);
            _buttonPrev.onClick.AddListener(SetPreviousValue);
        }

        protected virtual void OnDisable()
        {
            _buttonNext.onClick.RemoveListener(SetNextValue);
            _buttonPrev.onClick.RemoveListener(SetPreviousValue);
        }

        protected int GetClampedValue(int value, int maxValue, int minValue = 0)
        {
            if (_circleSwitch)
            {
                if (value < minValue)
                    return maxValue;

                if (value > maxValue)
                    return minValue;
            }
            else
                value = Mathf.Clamp(value, minValue, maxValue);

            return value;
        }

        protected virtual void TextPanelSetup(string text)
        {
            _valueTxt.text = text;
        }

        protected abstract void SetNextValue();
        protected abstract void SetPreviousValue();
    }
}
