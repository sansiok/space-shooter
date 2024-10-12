using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private SpriteRenderer _sprie;

        private float _speed = .5f;
        private float _positionMinY;
        private Vector2 _restartPosition;

        private void Awake()
        {
            _restartPosition = transform.position;
            _positionMinY = _sprie.bounds.size.y * 2 - _restartPosition.y; // две высоты спрайта - начальная
        }
        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            if (transform.position.y <= -_positionMinY)
            {
                transform.position = _restartPosition;
            }
        }

    }
}
