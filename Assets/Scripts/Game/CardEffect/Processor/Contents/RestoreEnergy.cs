using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class RestoreEnergyProcessor : ICardEffectProcessor
    {
        public int energyRestoreAmount;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            CardEffectProcessor.Instance.RestoreEnergy(energyRestoreAmount);
        }
    }
}

