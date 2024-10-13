using System;
using Game.Parameter.Damage;
using Game.Unit;
using UnityEngine;

namespace Game.Bullet
{
    [RequireComponent(typeof(BulletStatus))]
    public class BulletHitFeedback : MonoBehaviour
    {
        BulletStatus _bulletStatus;
        void Awake()
        {
            _bulletStatus = GetComponent<BulletStatus>();
        }

        public int CalcDamage(UnitStatus defenceStatus)
        {
            return DamageCalculator.CalcDamage(_bulletStatus.AttackNormal, defenceStatus);
        }

        public void OnHit()
        {
            Destroy(gameObject);
        }
    }
}