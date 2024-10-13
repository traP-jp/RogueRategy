using System;
using System.Linq;
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
        [SerializeField] int _defenceDefault;
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
            set => _attackNormal = value;
        }

        public int AttackNow
        {
            get
            {
                int nowAttack = AttackNormal;
                foreach (var buff in _buffStack.NowBuff.Where(b => b.BuffKind == BuffKind.IncreaseAttack))
                {
                    nowAttack += int.Parse(buff.BuffInfos[1]);
                    nowAttack = Mathf.RoundToInt(float.Parse(buff.BuffInfos[0]) * nowAttack);
                }

                return nowAttack;
            }
        }

        public int DefenceDefault => _defenceDefault;

        public int DefenceNow
        {
            get
            {
                int nowDefence = 0;
                foreach (var buff in _buffStack.NowBuff.Where(b => b.BuffKind == BuffKind.IncreaseDefence))
                {
                    nowDefence += int.Parse(buff.BuffInfos[1]);
                    nowDefence = Mathf.RoundToInt(float.Parse(buff.BuffInfos[0]) * nowDefence);
                }
                return nowDefence;
            }
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