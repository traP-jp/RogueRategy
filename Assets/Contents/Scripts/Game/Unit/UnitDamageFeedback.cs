using System;
using Game.UI.Damage;
using UniRx;
using UnityEngine;

namespace Game.Unit
{
    public class UnitDamageFeedback : MonoBehaviour
    {
        [SerializeField] UnitStatus _status;
        void Start()
        {
            _status.HealthPoint.Pairwise()
                .Where(p => p.Current - p.Previous < 0)
                .Subscribe(p => DamageNumberUI.Instance.GenerateDamage(p.Previous - p.Current, transform.position));
            _status.HealthPoint.Pairwise()
                .Where(p => p.Current - p.Previous > 0)
                .Subscribe(p => DamageNumberUI.Instance.GenerateHeal(p.Current - p.Previous, transform.position));
        }
    }
}