using UnityEngine;

namespace Code.Presets.Animation
{
    [CreateAssetMenu(fileName = "New blink animation", menuName = "Source/Preset/Animation/Blink")]
    public class BlinkPreset : ScriptableObject
    {
        [SerializeField] private BlinkAnimation _preset;

        public BlinkAnimation Preset => _preset;
    }
}
