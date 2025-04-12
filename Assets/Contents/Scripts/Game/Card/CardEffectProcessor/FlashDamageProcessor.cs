using System.Collections.Generic;
using Game.Card.CardEffectSetting;
using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class FlashDamageProcessor : MonoBehaviour
    {
        public void Process(UnitStatus userStatus, FlashDamage flashDamage)
        {
            List<Transform> oppositeTransforms;
            if (userStatus.IsPlayerSide)
            {
                oppositeTransforms = UnitTargetDecider.Instance.GetEnemySideTransforms();
            }
            else
            {
                oppositeTransforms = UnitTargetDecider.Instance.GetPlayerSideTransforms();
            }

            foreach (var tr in oppositeTransforms)
            {
                tr.GetComponentInChildren<UnitStatus>().HealthPoint.Value -= Mathf.RoundToInt(userStatus.AttackNow * flashDamage.DamageRatio);
            }
        }
    }
}