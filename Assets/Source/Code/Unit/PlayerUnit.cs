using UnityEngine;
using Code.UI;
using Code.Unit.Death;
using Code.Core.Interfaces;
using Code.Unit.DamageVisualizer;
using Code.Presets.Animation;

namespace Code.Unit.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PlayerUnit : Unit
    {
        [SerializeField] private ShakePreset _shakePreset;

        private IMover _mover;

        public void Initialize(GameOverPanel gameOverPanel, HealthView healthView)
        {
            _mover = new PlayerMover(GetComponent<Rigidbody2D>(), Config.MovementSpeed);
            IDamageVisualizer visualizer = new PlayerDamageVisualizer(gameObject, _shakePreset);

            Initialize(new PlayerDeath(gameOverPanel, Config.DeathParticles, this), visualizer, healthView);
        }

        private void FixedUpdate()
        {
            _mover.Move();
        }
    }
}