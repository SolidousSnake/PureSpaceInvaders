using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using Code.Unit.Enemy;
using Code.Core.Factories;
using Code.Score.Model;
using System.Threading;

namespace Code.Spawners
{
    public sealed class EnemySpawner
    {
        private readonly EnemyFactory _enemyFactory;

        private readonly MapConfig _mapConfig;

        private readonly SpawnerConfig _spawnerConfig;

        private readonly ScoreModel _scoreModel;

        private CancellationTokenSource _cancellationToken;

        public EnemySpawner(MapConfig mapConfig, SpawnerConfig spawnerConfig, ScoreModel scoreModel)
        {
            _mapConfig = mapConfig;
            _spawnerConfig = spawnerConfig;
            _scoreModel = scoreModel;
            _enemyFactory = new EnemyFactory(_spawnerConfig.Enemy);
        }

        public void CancelSpawn()
        {
            _cancellationToken?.Cancel();
        }

        public async UniTaskVoid SpawnEnemiesAsync()
        {
            _cancellationToken = new CancellationTokenSource();

            while (_cancellationToken.IsCancellationRequested == false)
            {
                Enemy enemy = _enemyFactory.CreateObject(GetRandomPosition());
                
                enemy.Initialize(new EnemyDeath(enemy, _scoreModel, enemy.Config.DeathParticles));

                await UniTask.Delay(TimeSpan.FromSeconds(_spawnerConfig.SpawnDelay), ignoreTimeScale: false);
            }
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 position = new(
                UnityEngine.Random.Range(-_mapConfig.BorderRange, _mapConfig.BorderRange),
                              _mapConfig.TopPosition, 0f);
            return position;
        }
    }
}
