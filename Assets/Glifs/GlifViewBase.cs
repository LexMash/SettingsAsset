using System;
using UnityEngine;
using UnityEngine.UI;

namespace Glifs
{
    public abstract class GlifViewBase : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private InputAction _action;

        private IGlifsFeature _feature;

        protected virtual void Awake()
        {
            _feature = GetFeature();

            if (_feature == null)
                throw new NullReferenceException($"{gameObject.name} cannot load GlifsFeature");
        }

        protected void OnEnable()
        {
            SetSprite();

            _feature.OnChanged += FeatureChanged;
        }

        protected void OnDisable()
        {
            _feature.OnChanged -= FeatureChanged;
        }

        private void FeatureChanged()
        {
            SetSprite();
        }

        protected virtual void SetSprite()
        {
            var sprite = GetSprite(_action);
            _image.sprite = sprite;
        }

        protected virtual Sprite GetSprite(InputAction action)
        {
            Glif[] glifs = _feature.CurrentGlifsScheme.Glifs;

            foreach(var glif in glifs)
            {
                if (action == glif.Action)
                    return glif.Icon;
            }

            Debug.LogWarning($"{gameObject.name} cannot find Sprite for action {action} in {_feature.CurrentGlifsScheme}");
            return null;
        }

        protected abstract IGlifsFeature GetFeature();
    }
}
