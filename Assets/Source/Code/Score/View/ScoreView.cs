using UnityEngine;
using TMPro;

namespace Code.Score.View
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private string _format = "Score: ";

        public void SetAmount(int value)
        {
            _label.text = _format + value.ToString();
        }
    }
}