using System;
using System.Collections.Generic;

namespace Glifs
{
    public class GlifsFeature : IGlifsFeature
    {
        public event Action OnChanged;

        private static class Keys
        {
            public const string GlifsSchemesPath = "";
        }

        public GlifsScheme CurrentGlifsScheme { get; private set; }

        private Dictionary<InputsSchemes, GlifsScheme> _glifsSchemesMap = new Dictionary<InputsSchemes, GlifsScheme>();
       
        public GlifsFeature(GlifsScheme[] glifsSchemes, GlifsScheme currentGlifsScheme = null)
        {
            for (int i = 0; i < glifsSchemes.Length; i++)
            {
                var glifsScheme = glifsSchemes[i];
                _glifsSchemesMap.Add(glifsScheme.InputScheme, glifsScheme);
            }

            CurrentGlifsScheme = currentGlifsScheme;
        }

        public void SetScheme(InputsSchemes scheme)
        {
            if (scheme == CurrentGlifsScheme.InputScheme)
                return;

            if (_glifsSchemesMap.ContainsKey(scheme))
            {
                CurrentGlifsScheme = _glifsSchemesMap[scheme];
                OnChanged?.Invoke();
            }
            else
                throw new NullReferenceException($"GlifsSchemesMap not contains input scheme {scheme}");
            
        }

        //это наверно не сюда...
        //private void Initialize()
        //{
        //    var glifsSchemes = Resources.LoadAll<GlifsScheme>(Keys.GlifsSchemesPath);
        //}
    }
}
