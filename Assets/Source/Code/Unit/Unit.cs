using Code.Core.Interfaces;
using UnityEngine;

namespace Code.Unit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private UnitConfig _config;

        private Health _health;

        public UnitConfig Config => _config;

        public Health Health => _health;

        public void Initialize(IDeath death, IDamageVisualizer damageVisualizer = null, HealthView healthView = null)
        {
            _health = new Health(_config.MaxHealth, death, damageVisualizer, healthView);
        }
    }
}