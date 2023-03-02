using UnityEngine;

namespace SettingsAggregator.Implementation.Sounds.Realisation
{
    [CreateAssetMenu(fileName = "UnitySoundLayersScheme", menuName = "SettingsAggregator/Sound/UnitySoundLayersScheme")]
    public class UnitySoundLayersScheme : ScriptableObject
    {
        [field: SerializeField] public UnitySoundLayerCategoryLink[] Links;
    }
}
