using UnityEngine;
using TMPro;

namespace Code.Unit
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _format = "HP: ";

        public void SetAmount(float value)
        {
            _label.text = _format + value.ToString();
        }
    }
}