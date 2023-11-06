using Code.Unit.Player;
using UnityEngine;

namespace Code.Unit.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Asteroid : Enemy
    {
        private EnemyConfig _config;

        private void Start()
        {
            if (Config is EnemyConfig)
            {
                _config = (EnemyConfig)Config;
                GetComponent<Rigidbody2D>().gravityScale = Config.MovementSpeed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {            
            if (collision.collider.TryGetComponent<PlayerUnit>(out var player))
            {
                player.Health.ApplyDamage(_config.Damage);
                Despawn();
            }
        }
    }
}