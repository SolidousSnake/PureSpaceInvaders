using Code.Core.Interfaces;
using Code.Presets.Animation;
using DG.Tweening;
using UnityEngine;

namespace Code.Unit.DamageVisualizer
{
    public sealed class PlayerDamageVisualizer : IDamageVisualizer
    {
        private readonly GameObject _selfGameObject;
        private readonly Transform _selfTransform;

        private readonly Vector3 _strength;

        private readonly float _duration;
        private readonly float _randomness;

        private readonly int _vibrato;

        private readonly bool _fadeOut;

        private readonly ShakeRandomnessMode _shakeRandomnessMode;

        private readonly Ease _ease;

        public PlayerDamageVisualizer(GameObject gameObject, ShakePreset preset) 
        {
            _selfGameObject = gameObject;
            _selfTransform = gameObject.transform;

            _strength = preset.Preset.Strength;
            _duration = preset.Preset.Duration;
            _randomness = preset.Preset.Randomness;
            _vibrato = preset.Preset.Vibrato;
            _fadeOut = preset.Preset.FadeOut;
            _shakeRandomnessMode = preset.Preset.RandomnessMode;
            _ease = preset.Preset.Ease;
        }

        public void VisualizeDamage()
        {
               _selfTransform.DOShakeRotation(_duration, _strength, _vibrato, _randomness, _fadeOut, _shakeRandomnessMode)
                 .SetEase(_ease)
                 .SetLink(_selfGameObject)
                 .OnComplete(ResetRotation);
        }

        private void ResetRotation()
        {
            _selfTransform.DORotate(Vector3.zero, _duration)
                .SetEase(_ease)
                .SetLink(_selfGameObject);
        }
    }
}
