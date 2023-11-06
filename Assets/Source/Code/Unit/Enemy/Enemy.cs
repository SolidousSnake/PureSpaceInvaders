using Code.Core.Interfaces;
using Code.Presets.Animation;
using Code.Unit.DamageVisualizer;
using NTC.Pool;
using UnityEngine;

namespace Code.Unit.Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : Unit
    {
        [SerializeField] private BlinkAnimationPreset _blinkPreset;

        public void Initialize(IDeath death)
        {
            Initialize(death, new EnemyDamageVisualizer(GetComponent<SpriteRenderer>(), _blinkPreset));
        }

        public void Despawn()
        {
            NightPool.Despawn(this);
        }
    }
}