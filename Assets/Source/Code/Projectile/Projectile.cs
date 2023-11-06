using NTC.Pool;
using UnityEngine;

namespace Code.Projectile
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Projectile : MonoBehaviour, IDespawnable
    {
        private Rigidbody2D _rigidbody;

        private float _damage;
        private float _speed;

        public void Initialize(float damage, float speed)
        {
            if (damage > 0)
                _damage = damage;
            if (speed > 0)
                _speed = speed;

            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            _rigidbody.velocity = Vector2.up * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Unit.Unit unit))
            {
                unit.Health.ApplyDamage(_damage);
            }
            Despawn();
        }

        public void OnDespawn()
        {
            ResetRigidbody();
            ResetPosition();
        }

        private void Despawn()
        {
            NightPool.Despawn(this);
        }

        private void ResetPosition()
        {
            transform.position = Vector3.zero;
        }

        private void ResetRigidbody()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}