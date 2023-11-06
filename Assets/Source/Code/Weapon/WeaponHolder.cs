using UnityEngine;

namespace Code.Weapon
{
    public sealed class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private Gun[] _guns;

        private Gun _currentGun;

        private PlayerInput _playerInput;

        private int _index;

        private void Awake()
        {
            _index = 0;
            _currentGun = _guns[0];

            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Upgrade.performed += context => Upgrade();
            _playerInput.Player.Shoot.performed += context => ShootGun();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Upgrade.performed -= context => Upgrade();
            _playerInput.Player.Shoot.performed -= context => ShootGun();
        }

        public void Upgrade()
        {
            if (_index + 1 <= _guns.Length - 1)
            {
                _index++;
                _currentGun.gameObject.SetActive(false);
                _guns[_index].gameObject.SetActive(true);
                _currentGun = _guns[_index];
            }
        }

        public void ShootGun()
        {
           _currentGun.Shoot();
        }
    }
}