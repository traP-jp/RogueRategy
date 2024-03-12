using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class RestoreEnergy : ICardEffect
    {
        public int energyRestoreAmount;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            CardEffectProcessor.Instance.RestoreEnergy(energyRestoreAmount);
        }
    }
}

