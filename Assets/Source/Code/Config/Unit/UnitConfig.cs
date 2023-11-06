using UnityEngine;

public class UnitConfig : ScriptableObject
{
    [SerializeField] private ParticleSystem _deathParticles;

    [field: SerializeField] public float MaxHealth { get;  private set; }
    [field: SerializeField] public float MovementSpeed { get;  private set; }

    public ParticleSystem DeathParticles => _deathParticles;
}
