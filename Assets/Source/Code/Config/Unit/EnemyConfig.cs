using UnityEngine;

[CreateAssetMenu(fileName = "New enemy config", menuName = "Source/Config/Unit/Enemy")]
public class EnemyConfig : UnitConfig
{
    [field: SerializeField] public int Reward { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
}
