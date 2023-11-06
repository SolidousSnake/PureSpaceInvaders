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

        private IDamageVisualizer _visualizer;

        public void Initialize(GameOverPanel gameOverPanel, HealthView healthView)
        {
            _visualizer = new PlayerDamageVisualizer(gameObject, _shakePreset);
            Initialize(new PlayerDeath(gameOverPanel, Config.DeathParticles, this), _visualizer, healthView);

            _mover = new PlayerMover(GetComponent<Rigidbody2D>(), Config.MovementSpeed);
        }

        private void FixedUpdate()
        {
            _mover.Move();
        }
    }
}