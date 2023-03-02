using System;
using UnityEngine;

namespace Glifs
{
    [Serializable]
    public class Glif
    {
        [SerializeField] private InputAction _action;
        [SerializeField] private Sprite _icon;

        public InputAction Action => _action;
        public Sprite Icon => _icon;
    }
}
