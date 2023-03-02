using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace SettingsAggregator.UI
{
    public abstract class UISettingsElementsHandlerBase : MonoBehaviour
    {
        [SerializeField] private UISettingsElementBase[] _elements;
        [SerializeField] private UISettingsElementBase _defaultSelected;

        private UISettingsElementBase _selectedElement;

        protected virtual void Awake()
        {
            GetInputSystem();
        }

        protected virtual void OnEnable()
        {
            SetDefaultSelected();

            SubscribeInput();

            foreach (var element in _elements)
            {
                element.Selected += OnElementSelected;
                element.Deselected += OnElementDeselected;
            }
                
        }

        protected virtual void OnDisable()
        {
            UnsubscribeInput();

            foreach (var element in _elements)
            {
                element.Selected -= OnElementSelected;
                element.Deselected -= OnElementDeselected;
            }
                
        }

        protected virtual void PrevPerformed(InputAction.CallbackContext obj)
        {
            _selectedElement?.Changer.SetPrevValue();
        }

        protected virtual void NextPerformed(InputAction.CallbackContext obj)
        {
            _selectedElement?.Changer.SetNextValue();
        }

        protected virtual void OnElementSelected(UISettingsElementBase element)
        {
            _selectedElement = element;
        }

        private void OnElementDeselected(UISettingsElementBase obj)
        {
            _selectedElement = null;
        }

        protected abstract void GetInputSystem();
        protected abstract void SubscribeInput();
        protected abstract void UnsubscribeInput();

        private void SetDefaultSelected()
        {
            _selectedElement = _defaultSelected == null ? _elements[0] : _defaultSelected;
            EventSystem.current.SetSelectedGameObject(_selectedElement.gameObject);
        }        
    }
}
