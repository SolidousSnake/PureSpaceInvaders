using Code.Core.Interfaces;
using Code.UI;
using UnityEngine;
using Cysharp.Threading.Tasks;
using NTC.Pool;
using Code.Unit.Player;

namespace Code.Unit.Death
{
    public sealed class PlayerDeath : IDeath
    {
        private readonly PlayerUnit _player;
        private readonly GameOverPanel _panel;
        private readonly ParticleSystem _particleSystemPrefab;

        public PlayerDeath(GameOverPanel panel, ParticleSystem _particleSystem, PlayerUnit player)
        {
            _panel = panel;
            _particleSystemPrefab = _particleSystem;
            _player = player;
        }

        public async void ApplyDeath()
        {
            var particles = NightPool.Spawn(_particleSystemPrefab, _player.transform.position, Quaternion.identity);
            _player.gameObject.SetActive(false);
            await UniTask.WaitUntil(() => particles.gameObject.activeSelf == false);
            _panel.gameObject.SetActive(true);
        }
    }
}
