using Code.Core.Interfaces;
using Code.Score.Model;
using Code.Unit.Enemy;
using NTC.Pool;
using UnityEngine;

public class EnemyDeath : IDeath
{
    private readonly GameObject _selfEnemy;
    private readonly ParticleSystem _particleSystemPrefab;
    private readonly ScoreModel _scoreModel;
    private readonly int _reward;

    public EnemyDeath(Enemy selfEnemy, ScoreModel scoreModel, ParticleSystem particleSystem)
    {
        var config = selfEnemy.Config as EnemyConfig;

        _selfEnemy = selfEnemy.gameObject;
        _scoreModel = scoreModel;
        _reward = config.Reward; 
        _particleSystemPrefab = particleSystem;
    }

    public void ApplyDeath()
    {
        _scoreModel.IncrementScore(_reward);
        NightPool.Spawn(_particleSystemPrefab, _selfEnemy.transform.position, Quaternion.identity).DespawnOnComplete();
        NightPool.Despawn(_selfEnemy);
    }
}
