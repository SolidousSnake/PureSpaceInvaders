using Code.Unit.Enemy;
using UnityEngine;

[CreateAssetMenu(fileName = "New spawner config", menuName = "Source/Config/Level/Spawner")]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay;

    public Enemy Enemy => _enemy;
    public float SpawnDelay => _spawnDelay;
}
