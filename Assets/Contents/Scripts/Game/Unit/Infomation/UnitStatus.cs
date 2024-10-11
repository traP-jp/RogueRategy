using System;
using NaughtyAttributes;
using UniRx;
using UnityEngine;

namespace Game.Unit
{
    public class UnitStatus : MonoBehaviour
    {
        public IntReactiveProperty HealthPoint = new IntReactiveProperty();
        public IntReactiveProperty MaxHealthPoint = new IntReactiveProperty();
        [SerializeField] float _speed;
        [SerializeField] int _attackDefault;
        [SerializeField, ReadOnly] int _attackNormal;
        [SerializeField, ReadOnly] int _attackNow;
        [SerializeField] int _defence;
        [SerializeField] bool _isPlayerSide;
        [SerializeField] UnitBuffStack _buffStack;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int AttackDefault => _attackDefault;

        public int AttackNormal
        {
            get => _attackNormal;
            set
            {
                _attackNormal = value;
                AttackNow = _attackNormal;//本当はバフの影響も考慮して値を出す
            }
        }

        public int AttackNow
        {
            get => _attackNow;
            set => _attackNow = value;
        }

        public int Defence
        {
            get => _defence;
            set => _defence = value;
        }

        public bool IsPlayerSide
        {
            get => _isPlayerSide;
            set => _isPlayerSide = value;
        }

        public UnitBuffStack GetBuffStack()
        {
            return _buffStack;
        }

        void Awake()
        {
            HealthPoint
                .Where(hp => hp > MaxHealthPoint.Value)
                .Subscribe(_ => HealthPoint.Value = MaxHealthPoint.Value);
        }
    }
}