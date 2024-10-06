using NaughtyAttributes;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletStatus : MonoBehaviour
    {
        [SerializeField, ReadOnly] bool _isPlayerSide;
        [SerializeField, ReadOnly] int _attack;
        [SerializeField] int _defaultAttack;

        public bool IsPlayerSide
        {
            get => _isPlayerSide;
            set => _isPlayerSide = value;
        }

        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }

        public int DefaultAttack => _defaultAttack;
    }
}