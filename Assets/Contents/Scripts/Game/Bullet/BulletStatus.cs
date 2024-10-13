using NaughtyAttributes;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletStatus : MonoBehaviour
    {
        [SerializeField, ReadOnly] bool _isPlayerSide;
        [SerializeField, ReadOnly] int _attackNormal;
        [SerializeField] int _defaultAttack;

        public bool IsPlayerSide
        {
            get => _isPlayerSide;
            set => _isPlayerSide = value;
        }

        public int AttackNormal
        {
            get => _attackNormal;
            set => _attackNormal = value;
        }

        public int DefaultAttack => _defaultAttack;
    }
}