using System;
using UnityEngine;

namespace Game.Bullet.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovementSimple : MonoBehaviour, IBulletMovement
    {
        Rigidbody2D _rigidbody;

        [SerializeField] float _speed;
        public Vector2 Orientation { get; set; }

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            _rigidbody.velocity = Orientation.normalized * _speed;
        }
    }
}