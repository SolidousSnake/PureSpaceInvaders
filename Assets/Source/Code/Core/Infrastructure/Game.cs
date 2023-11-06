using Code.Spawners;
using UnityEngine;
using Code.Score.Model;
using Code.Score.View;

namespace Code.Core.Infrastructure
{
    public sealed class Game : MonoBehaviour
    {
        private EnemySpawner _enemySpawner;

        public void Initialize(MapConfig mapConfig, SpawnerConfig spawnerConfig, ScoreView scoreView)
        {
            ScoreModel scoreModel = new(scoreView);
            _enemySpawner = new EnemySpawner(mapConfig, spawnerConfig, scoreModel);
            StartSpawn();
        }

        public void StartSpawn()
        {
            _enemySpawner.SpawnEnemiesAsync().Forget();
        }

        public void StopSpawn()
        {
            _enemySpawner.CancelSpawn();
        }
    }
}