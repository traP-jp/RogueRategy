using UnityEngine;

namespace Game.Bullet
{
    public class BulletHitFeedbackHPAbsorb : BulletHitFeedback
    {
        [SerializeField] BulletInitializer _initializer;
        [SerializeField, Range(0,1)] float _absorbRate;
        public override void OnHit()
        {
            _initializer.GetUserStatus().HealthPoint.Value += Mathf.RoundToInt(DamageNum * _absorbRate);
            base.OnHit();
        }
    }
}