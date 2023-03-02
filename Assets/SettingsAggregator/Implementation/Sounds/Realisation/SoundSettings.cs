using System;
using System.Collections.Generic;

namespace SettingsAggregator.Implementation.Sounds.Realisation
{
    public class SoundSettings : SettingsBase<ISoundLayer>, ISettings 
    {
        public ISettingsElement[] Elements => _elements;

        private readonly new ISoundLayer[] _elements;
        private readonly Dictionary<SoundLayerCategory, ISoundLayer> _elementsMap = new Dictionary<SoundLayerCategory, ISoundLayer>();

        public SoundSettings(params ISoundLayer[] elements)
        {
            _elements = elements;

            foreach (var element in _elements)
            {
                _elementsMap.Add(element.Category, element);
                element.OnChanged += OnElementChanged;
            }
        }

        public ISoundLayer GetSettingsElement(SoundLayerCategory category)
        {
            if (_elementsMap.ContainsKey(category))
                return _elementsMap[category];

            throw new NullReferenceException($"Elements Map from {GetType()} not contains sound layer from {category} category");
        }
    }
}
