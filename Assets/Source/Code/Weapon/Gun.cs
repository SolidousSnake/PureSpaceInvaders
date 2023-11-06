using Code.Core.Factories;
using UnityEngine;

namespace Code.Weapon
{
    public sealed class Gun : MonoBehaviour
    {
        [SerializeField] private GunConfig _config;

        [SerializeField] private Transform _barrel;

        private ProjectileFactory _factory;

        private void Awake()
        {
            _factory = new ProjectileFactory(_config.Projectile);
        }

        public void Shoot()
        {
            var bullet = _factory.CreateObject(_barrel);
            bullet.Initialize(_config.Damage, _config.ProjectileSpeed);
        }
    }
}