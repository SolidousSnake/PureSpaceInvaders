using Code.Unit.Player;
using UnityEngine;

namespace Code.Triggers
{
    public sealed class DamageTrigger : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerUnit>(out var player))
            {
                player.Health.ApplyDamage(_damage);
            }
        }
    }
}