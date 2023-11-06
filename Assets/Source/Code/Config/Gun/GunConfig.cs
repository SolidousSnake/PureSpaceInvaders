using Code.Projectile;
using UnityEngine;

[CreateAssetMenu(fileName = "New gun config", menuName = "Source/Config/Gun")]
public sealed class GunConfig : ScriptableObject
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;

    public Projectile Projectile => _projectile;
    public float Damage => _damage;
    public float ProjectileSpeed => _projectileSpeed;
}
