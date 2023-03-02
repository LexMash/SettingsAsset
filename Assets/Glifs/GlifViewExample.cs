using UnityEngine;

namespace Glifs
{
    public class GlifViewExample : GlifViewBase
    {
        protected override IGlifsFeature GetFeature()
        {
            Debug.Log($"{gameObject.name} try to load feature");

            return new GlifsFeature(null);
        }
    }
}
