using Code.Core.Interfaces;

namespace Code.Unit
{
    public class Health
    {
        private readonly HealthView _healthView;
        private readonly IDamageVisualizer _damageVisualizer;
        private readonly IDeath _death;
        
        private readonly float _maxHealth;
        private float _health;

        public Health(float health, IDeath death, IDamageVisualizer damageVisualizer)
        {
            _maxHealth = health;
            _health = health;
            _death = death;
            _damageVisualizer = damageVisualizer;
        }

        public Health(float health, IDeath death, IDamageVisualizer damageVisualizer, HealthView healthView)
        {
            _maxHealth = health;
            _health = health;
            _healthView = healthView;
            _damageVisualizer = damageVisualizer;
            _death = death;
            healthView.SetAmount(health);
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                return;

            _health -= damage;
            _healthView?.SetAmount(_health);
            _damageVisualizer?.VisualizeDamage();

            if (_health <= 0)
            {
                _health = 0;
                _death.ApplyDeath();
            }
        }

        public void ApplyHeal(float health)
        {
            if (health < 0)
                return;

            if (health < _maxHealth)
                _health += health;
            else
                _health = _maxHealth;

            _healthView?.SetAmount(health);
        }
    }
}