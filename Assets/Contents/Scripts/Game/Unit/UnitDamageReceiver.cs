using Game.Bullet;
using Game.UI.Damage;
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
            int damageNum = feedback.CalcDamage(_unitStatus);
            _unitStatus.HealthPoint.Value -= damageNum;
            feedback.OnHit();
        }
    }
}