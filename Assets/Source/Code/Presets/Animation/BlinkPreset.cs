using UnityEngine;

namespace Code.Presets.Animation
{

    [CreateAssetMenu(fileName = "New blink preset", menuName = "Source/Preset/Animation/Blink")]
    public class BlinkPreset : ScriptableObject
    {
        [SerializeField] private BlinkAnimationPreset _preset;

        public BlinkAnimationPreset Preset => _preset;
    }
}
