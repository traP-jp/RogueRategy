using System;
using UniRx;
using UnityEngine;

namespace Game.Unit
{
    public class UnitStatus : MonoBehaviour
    {
        public IntReactiveProperty HealthPoint = new IntReactiveProperty();
        public IntReactiveProperty MaxHealthPoint = new IntReactiveProperty();
        [SerializeField] float _speed;
        [SerializeField] int _attack;
        [SerializeField] int _defence;
        [SerializeField] bool _isPlayerSide;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public int Attack
        {
            get => _attack;
            set => _attack = value;
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

        void Awake()
        {
            HealthPoint
                .Where(hp => hp > MaxHealthPoint.Value)
                .Subscribe(_ => HealthPoint.Value = MaxHealthPoint.Value);
        }
    }
}