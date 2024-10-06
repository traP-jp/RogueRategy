using System;
using Game.Parameter.Damage;
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

        public int CalcDamage(int defence)
        {
            return DamageCalculator.CalcDamage(_bulletStatus.Attack, _bulletStatus.DefaultAttack, defence);
        }

        public void OnHit()
        {
            Destroy(gameObject);
        }
    }
}