using System;
using UnityEngine;

namespace SettingsAggregator.Implementation.Sounds
{
    public abstract class SoundLayerBase : ISoundLayer
    {
        public event Action OnChanged;
        public SoundLayerCategory Category { get; }
        public float CurrentVolume { get; private set; }
        public float CashedValue => _data.CashedValue;
        public float MaxVolume => _data.MaxVolume;
        public float MinVolume => _data.MinVolume;
        public bool IsEnable => CurrentVolume > MinVolume;

        private readonly SoundLayerData _data;
       
        public SoundLayerBase(SoundLayerData data)
        {
            _data = data;
        }

        public virtual void Enable(bool enable)
        {
            if (IsEnable && enable == false)
            {
                _data.CashedValue = CurrentVolume;
                SetVolume(MinVolume);
            }

            if (!IsEnable && enable == true)
                SetVolume(_data.CashedValue);
        }

        public virtual void SetVolume(float value)
        {
            CurrentVolume = Mathf.Clamp(value, MinVolume, MaxVolume);

            SetClampedValue(CurrentVolume);

            OnChanged?.Invoke();
        }

        protected virtual void StartVolumeInitialize()
        {
            if (CurrentVolume >= MinVolume)
            {
                SetVolume(CurrentVolume);
            }
            else
            {
                float v = GetDefaultValue();
                SetVolume(v);
            }
        }

        protected abstract void SetClampedValue(float value);
        protected abstract float GetDefaultValue();
    }
}
