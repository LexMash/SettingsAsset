using System;
using System.Collections.Generic;

namespace SettingsAggregator.Implementation
{
    /// <summary>
    /// основной базовый класс для всех наборов настроек
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SettingsBase<T> : IChangeable where T : IChangeable
    {
        public event Action OnChanged;
        
        protected readonly T[] _elements;
        private Dictionary<Type, T> _elementsMap = new Dictionary<Type, T>();

        public SettingsBase(params T[] elements)
        {
            _elements = elements;

            foreach(var element in _elements)
            {
                _elementsMap.Add(element.GetType(), element);
                element.OnChanged += OnElementChanged;
            }
        }

        public virtual P GetSettingsElement<P>() where P : T
        {
            var type = typeof(P);

            if (_elementsMap.ContainsKey(type))
                return (P)_elementsMap[type];

            throw new NullReferenceException($"Elements Map from {GetType()} not contains settings {type}");
        }

        protected virtual void OnElementChanged()
        {
            //тут надо подумать над защитой, что бы не вызывалось несколько раз подряд, если изменены несколько настроек
            //либо возвращать строку с изменённым параметром для перезаписи в дату конкретных данных

            OnChanged?.Invoke();
        }
    }
}
