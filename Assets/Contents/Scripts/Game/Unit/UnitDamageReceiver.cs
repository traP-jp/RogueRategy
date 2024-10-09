using System;
using Game.Bullet;
using Game.Parameter.Damage;
using UnityEngine;

namespace Game.Unit
{
    public class UnitDamageReceiver : MonoBehaviour
    {
        [SerializeField] UnitStatus _unitStatus;
        void Start()
        {
            gameObject.layer = _unitStatus.IsPlayerSide ? 6 : 8;
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            var feedback = other.GetComponent<BulletHitFeedback>();
            _unitStatus.HealthPoint.Value -= feedback.CalcDamage(_unitStatus.Defence);
            feedback.OnHit();
        }
    }
}