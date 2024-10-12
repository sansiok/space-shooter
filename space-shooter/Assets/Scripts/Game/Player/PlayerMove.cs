using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private DynamicJoystick _joystick;

        private Rigidbody2D _rigidbody2D;
        private float _speed = 4.5f;
        private Vector2 _direction = Vector2.zero;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _direction.x = _joystick.Horizontal;
                _direction.y = _joystick.Vertical;
                _rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * _direction);
            }
        }
    }
}

