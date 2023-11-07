using Code.Score.Model;
using Code.Score.View;
using Code.Spawners;
using Code.UI;
using Code.Unit;
using Code.Unit.Player;
using UnityEngine;

namespace Code.Core.Infrastructure
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerUnit _playerPrefab;

        [Header("Configs")]
        [SerializeField] private MapConfig _mapConfig;
        [SerializeField] private SpawnerConfig _spawnerConfig;

        [Header("Player UI")]
        [SerializeField] private GameObject _mobileUi;
        [SerializeField] private GameOverPanel _gameOverPanel;
        [SerializeField] private HealthView _playerHealthView;
        [SerializeField] private ScoreView _scoreView;

        private void Awake()
        {
            InitializeUi();
            InitializePlayer();

            EnemySpawner enemySpawner = new(_mapConfig, _spawnerConfig, new ScoreModel(_scoreView));
            enemySpawner.SpawnEnemiesAsync().Forget();
        }

        private void InitializePlayer()
        {
            var player = Instantiate(_playerPrefab);
            player.Initialize(_gameOverPanel, _playerHealthView);
        }

        private void InitializeUi()
        {
            if (Application.isMobilePlatform)
                _mobileUi.SetActive(true);
            else
                _mobileUi.SetActive(false);
        }
    }
}