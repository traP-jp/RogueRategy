using System.Collections;
using Game.Card;
using UnityEngine;

namespace Game.Unit.Movement
{
    public class UnitAttackSimple : MonoBehaviour
    {
        [SerializeField] CardEffectInfo _useCardEffect;
        [SerializeField] float _attackInterval;
        [SerializeField] UnitStatus _status;
        void Start()
        {
            StartCoroutine(AttackRegularly());
        }

        IEnumerator AttackRegularly()
        {
            while (true)
            {
                yield return new WaitForSeconds(_attackInterval);
                CardEffectUse.Instance.UseEffect(_useCardEffect, _status, transform.position);   
            }
        }
    }
}