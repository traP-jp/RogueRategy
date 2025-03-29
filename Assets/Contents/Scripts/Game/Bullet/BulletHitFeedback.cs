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
        protected int DamageNum;
        
        void Awake()
        {
            _bulletStatus = GetComponent<BulletStatus>();
        }

        public int CalcDamage(UnitStatus defenceStatus)
        {
            DamageNum = DamageCalculator.CalcDamage(_bulletStatus.AttackNormal, defenceStatus);
            return DamageNum;
        }

        public virtual void OnHit()
        {
            Destroy(gameObject);
        }
    }
}