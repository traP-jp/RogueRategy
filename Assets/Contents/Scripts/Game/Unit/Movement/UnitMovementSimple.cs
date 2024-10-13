using System;
using UnityEngine;

namespace Game.Unit.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitMovementSimple : MonoBehaviour, IUnitMovement
    {
        [SerializeField] float _shootDistance = 4;
        [SerializeField] float _force = 3;
        [SerializeField] float _forceDownRange = 1;
        [SerializeField] float _resistPower = 3;
        
        float _speed;
        Rigidbody2D _rigidbody;
        bool _isPlayerSide;
        float _speedSquared;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(bool isPlayerSide, float speed)
        {
            _speed = speed;
            _isPlayerSide = isPlayerSide;
            _speedSquared = _speed * _speed;
        }
        
        void FixedUpdate()
        {
            //ターゲット取得
            Transform targetTransform;
            if (_isPlayerSide)
            {
                targetTransform =
                    UnitTargetDecider.Instance.GetNearestTarget(
                        (Vector2)transform.position + Vector2.left * _shootDistance, false);
            }
            else
            {
                targetTransform =
                    UnitTargetDecider.Instance.GetNearestTarget(
                        (Vector2)transform.position + Vector2.right * _shootDistance, true);
            }

            Vector2 goalPosition;
            if (_isPlayerSide)
            {
                goalPosition = (Vector2)targetTransform.position + Vector2.left * _shootDistance;
            }
            else
            {
                goalPosition = (Vector2)targetTransform.position + Vector2.right * _shootDistance;
            }
            
            //ターゲットに向かう
            Vector2 deltaPos = goalPosition - (Vector2)transform.position;
            Vector2 forceVector;
            if (deltaPos.magnitude < _forceDownRange)
            {
                forceVector = deltaPos.normalized * (_force * deltaPos.magnitude) / _forceDownRange;
                _rigidbody.AddForce(-_rigidbody.velocity / _speed * _resistPower);
            }
            else
            {
                forceVector = deltaPos.normalized * _force;
                _rigidbody.AddForce(-_rigidbody.velocity.normalized * _resistPower / 4);
            }
            _rigidbody.AddForce(forceVector);
            
            //速度上限
            if (_rigidbody.velocity.sqrMagnitude > _speedSquared)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
            }
        }
    }
}