using Code.Unit.Enemy;
using UnityEngine;

namespace Code.Triggers
{
    public sealed class DespawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.Despawn();
            }
        }
    }
}