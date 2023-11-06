using UnityEngine;

[CreateAssetMenu(fileName = "New map config", menuName = "Source/Config/Level/Map")]
public class MapConfig : ScriptableObject
{
    [SerializeField] private float _topPosition;
    [SerializeField] private float _borderRange;

    public float TopPosition => _topPosition;
    public float BorderRange => _borderRange;
}