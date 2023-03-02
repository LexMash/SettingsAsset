using UnityEngine;

namespace Glifs
{
    [CreateAssetMenu(fileName = "Glifs Scheme", menuName = "GLIFS/Glifs Scheme")]
    public class GlifsScheme : ScriptableObject
    {
        [SerializeField] private InputsSchemes _scheme;
        [SerializeField] private Glif[] _glifs;

        public InputsSchemes InputScheme => _scheme;
        public Glif[] Glifs => _glifs;
    }
}
