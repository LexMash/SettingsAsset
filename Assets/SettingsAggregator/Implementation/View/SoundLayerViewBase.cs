using SettingsAggregator.Implementation.Sounds;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.Implementation.View
{
    public abstract class SoundLayerViewBase : MonoBehaviour
    {
        [SerializeField] private SoundLayerCategory _category;
        [SerializeField] private Slider _slider;
        [SerializeField] private Toggle _toggle;

        private ISoundLayer _soundLayer;
     
        protected virtual void Awake()
        {
            _soundLayer = GetLayer(_category);
            
            if (_slider)
            {
                _slider.maxValue = _soundLayer.MaxVolume;
                _slider.minValue = _soundLayer.MinVolume;
                _slider.value = _soundLayer.CurrentVolume;
            }

            if (_toggle)
                _toggle.isOn = _soundLayer.IsEnable;

            if (_soundLayer == null)
                throw new NullReferenceException($"{gameObject} cannot get SoundLayer");
        }

        protected virtual void OnEnable()
        {
            if (!_slider && !_toggle)
                Debug.LogWarning($"{gameObject.name} don`t have slider and toggle for change value");

            if (_slider)
                _slider.onValueChanged.AddListener(OnSliderValueChanged);

            if (_toggle)
                _toggle.onValueChanged.AddListener(OnToggleValueChanged);          
        }

        protected virtual void OnDisable()
        {
            if (_slider)
                _slider.onValueChanged.RemoveListener(OnSliderValueChanged);

            if (_toggle)
                _toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    
        protected virtual void OnSliderValueChanged(float value)
        {
            _soundLayer.SetVolume(value);
        }

        protected virtual void OnToggleValueChanged(bool flag)
        {
            _soundLayer.Enable(flag);
        }

        /// <summary>
        /// Обращаемся к настройкам звука и вытаскиваем конкретный SoundLayer
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        protected abstract ISoundLayer GetLayer(SoundLayerCategory category);
    }
}
