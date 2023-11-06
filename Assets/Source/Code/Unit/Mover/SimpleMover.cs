using Code.Core.Interfaces;
using UnityEngine;

namespace Code.Unit.Mover
{
    public sealed class SimpleMover : IMover
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Vector2 _direction;
        private readonly float _speed;

        public SimpleMover(Rigidbody2D rigidbody, Vector2 direction, float speed)
        {
            _rigidbody = rigidbody;
            _direction = direction;
            _speed = speed;
        }

        public void Move()
        {
            _rigidbody.velocity = _direction * _speed * Time.fixedDeltaTime;
        }
    }
}
