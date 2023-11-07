using UnityEngine;

namespace Code.Presets.Animation
{
    [CreateAssetMenu(fileName = "New shake animation", menuName = "Source/Preset/Animation/Shake")]
    public class ShakePreset : ScriptableObject
    {
        [SerializeField] private ShakeAnimation _preset;

        public ShakeAnimation Preset => _preset;
    }
}