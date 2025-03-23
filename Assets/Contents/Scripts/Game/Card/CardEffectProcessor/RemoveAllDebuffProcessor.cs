using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class RemoveAllDebuffProcessor : MonoBehaviour
    {
        public void Process(UnitStatus userStatus)
        {
            userStatus.GetBuffStack().RemoveAllDebuff();
        }
    }
}