using System;
using Game.Bullet.Movement;
using Game.Unit;
using UnityEngine;

namespace Game.Bullet
{
    [RequireComponent(typeof(BulletStatus))]
    public class BulletInitializer : MonoBehaviour
    {
        BulletStatus _bulletStatus;
        IBulletMovement _bulletMovement;
        void Awake()
        {
            _bulletStatus = GetComponent<BulletStatus>();
            _bulletMovement = GetComponent<IBulletMovement>();
        }

        public void Initialize(UnitStatus userStatus, Vector2 orientation)
        {
            _bulletStatus.Attack = userStatus.Attack;
            _bulletStatus.IsPlayerSide = userStatus.IsPlayerSide;
            gameObject.layer = _bulletStatus.IsPlayerSide ? 7 : 9;
            _bulletMovement.Orientation = orientation;
        }
    }
}