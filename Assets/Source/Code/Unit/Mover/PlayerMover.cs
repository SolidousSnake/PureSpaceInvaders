using Code.Core.Interfaces;
using UnityEngine;

namespace Code.Unit.Player
{
    public sealed class PlayerMover : IMover
    {
        private readonly float _speed;
        private readonly Rigidbody2D _rigidbody;
        private readonly PlayerInput _input;

        public PlayerMover(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;

            _input = new PlayerInput();
            _input.Enable();
        }

        public void Move()
        {
            float direction = _input.Player.Move.ReadValue<float>();
            float scaledSpeed = _speed * Time.fixedDeltaTime;
            _rigidbody.velocity = new Vector2(direction * scaledSpeed, _rigidbody.position.y);
        }
    }
}
