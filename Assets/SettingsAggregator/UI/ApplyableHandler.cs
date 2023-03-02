using UnityEngine;
using UnityEngine.UI;

namespace SettingsAggregator.UI
{
    public class ApplyableHandler : MonoBehaviour
    {
        [SerializeField] private Button _applyBtn;

        private IApplyable[] _applyables;

        private void Awake()
        {
            _applyables = GetComponentsInChildren<IApplyable>();
        }

        private void OnEnable()
        {
            _applyBtn.onClick.AddListener(ApplyBtnPressed);
        }

        private void OnDisable()
        {
            _applyBtn.onClick.RemoveListener(ApplyBtnPressed);
        }

        private void ApplyBtnPressed()
        {
            foreach (var applyable in _applyables)
                if(applyable.WasChanged)
                    applyable.Apply();
        }
    }
}
