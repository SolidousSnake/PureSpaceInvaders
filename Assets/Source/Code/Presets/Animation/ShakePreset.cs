using UnityEngine;

namespace Code.Presets.Animation
{
    [CreateAssetMenu(fileName = "New shake preset", menuName = "Source/Preset/Animation/Shake")]
    public class ShakePreset : ScriptableObject
    {
        [SerializeField] private ShakeAnimationPreset _preset;

        public ShakeAnimationPreset Preset => _preset;
    }
}