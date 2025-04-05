using Game.Bullet.Movement;
using Game.Unit;
using UnityEngine;

namespace Game.Bullet
{
    [RequireComponent(typeof(BulletStatus))]
    public class BulletInitializer : MonoBehaviour, IBulletInitializer
    {
        BulletStatus _bulletStatus;
        IBulletMovement _bulletMovement;
        UnitStatus _userStatus;
        
        void Awake()
        {
            _bulletStatus = GetComponent<BulletStatus>();
            _bulletMovement = GetComponent<IBulletMovement>();
        }

        public void Initialize(UnitStatus userStatus)
        {
            _userStatus = userStatus;
            _bulletStatus.AttackNormal = userStatus.AttackNow * _bulletStatus.AttackRatio;
            _bulletStatus.IsPlayerSide = userStatus.IsPlayerSide;
            gameObject.layer = _bulletStatus.IsPlayerSide ? 7 : 9;
            _bulletMovement.Orientation = userStatus.WeaponOrientation;
        }

        public UnitStatus GetUserStatus()
        {
            return _userStatus;
        }
    }
}