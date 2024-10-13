using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class AddBuffProcessor : MonoBehaviour
    {
        public void Process(UnitStatus userStatus, Buff buff)
        {
            buff.LeftTime = buff.EffectTime;
            userStatus.GetBuffStack().NowBuff.Add(buff);
        }
    }
}