using Code.Core.Interfaces;
using Code.Presets.Animation;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Unit.DamageVisualizer
{
    public sealed class EnemyDamageVisualizer : IDamageVisualizer
    {
        private readonly float _delay;

        private readonly Color _defaultColor;
        private readonly Color _damagedColor;

        private readonly SpriteRenderer _spriteRenderer;

        public EnemyDamageVisualizer(SpriteRenderer spriteRenderer, BlinkAnimationPreset preset) 
        { 
            _spriteRenderer = spriteRenderer;
            _defaultColor = spriteRenderer.color;
            _damagedColor = preset.Color;
            _delay = preset.Duration;
        }

        public async void VisualizeDamage()
        {
            _spriteRenderer.color = _damagedColor;
            await UniTask.Delay(System.TimeSpan.FromSeconds(_delay));
            _spriteRenderer.color = _defaultColor;
        }
    }
}
