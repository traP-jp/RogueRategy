using Game.Card;
using UnityEngine;

namespace Game.Unit.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitMovementSimple2 : MonoBehaviour, IUnitMovement
    {
        [SerializeField] float _shootDistance = 4;
        [SerializeField] float _velocity;
        [SerializeField] UnitStatus _status;
        [SerializeField] CardEffectInfo _attackCardInfo;
        [SerializeField] float _shootInterval;

        enum State
        {
            Move,
            StopAttack
        }
        
        float _speed;
        Rigidbody2D _rigidbody;
        bool _isPlayerSide;
        float _nowAttackTime;
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize(bool isPlayerSide, float speed)
        {
            _speed = speed;
            _isPlayerSide = isPlayerSide;
        }
        
        void FixedUpdate()
        {
            //ターゲット取得
            Transform targetTransform = UnitTargetDecider.Instance.GetNearestTarget(transform.position, !_isPlayerSide);
            State nowState;
            if (Vector2.Distance(targetTransform.position, transform.position) < _shootDistance)
            {
                nowState = State.StopAttack;
            }
            else
            {
                nowState = State.Move;
            }

            switch (nowState)
            {
                case State.Move:
                    transform.rotation = Quaternion.Euler(0,0,0);
                    _rigidbody.velocity = (_status.IsPlayerSide ? Vector2.right : Vector2.left) * _velocity;
                    break;
                case State.StopAttack:
                    _rigidbody.velocity = Vector2.zero;
                    _nowAttackTime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(0, 0,
                        Vector2.SignedAngle(Vector2.right, targetTransform.position - transform.position));
                    _status.WeaponOrientation = targetTransform.position - transform.position;
                    if (_nowAttackTime > _shootInterval)
                    {
                        _nowAttackTime = 0;
                        CardEffectUse.Instance.UseEffect(_attackCardInfo, _status, transform.position);   
                    }
                    break;
            }
        }
    }
}