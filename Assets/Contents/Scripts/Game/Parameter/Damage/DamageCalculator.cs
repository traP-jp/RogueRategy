using System.Linq;
using Game.Unit;
using UnityEngine;

namespace Game.Parameter.Damage
{
    public static class DamageCalculator
    {
        public static int CalcDamage(int bulletAttack, UnitStatus defenceStatus)
        {
            float damageReceiveRatio = 1;
            foreach (var buff in defenceStatus.GetBuffStack().NowBuff.Where(b => b.BuffKind == BuffKind.DamageReceiveRatio))
            {
                damageReceiveRatio *= float.Parse(buff.BuffInfos[0]);
            }
            return Mathf.RoundToInt((bulletAttack - defenceStatus.DefenceNow) * damageReceiveRatio);
        }
    }
}