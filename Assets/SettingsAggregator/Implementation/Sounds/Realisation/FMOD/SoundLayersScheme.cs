using UnityEngine;

namespace SettingsAggregator.Implementation.Sounds.Realisation
{
    //это конфигурационный файл для вытаскивания нужных нам каналов из мозгов аудиосистемы
    //для FMOD смотрим это видео, что бы вспомнить почему так https://www.youtube.com/watch?v=_D-OZaCH8os

    [CreateAssetMenu(fileName = "SoundLayersScheme", menuName = "SettingsAggregator/Sound/SoundLayersScheme")]
    public class SoundLayersScheme : ScriptableObject
    {
        [field: SerializeField] public SoundLayerCategoryLink[] Links;
    }
}
