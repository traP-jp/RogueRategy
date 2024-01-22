using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect
{
    [System.Serializable]
    public class RestoreEnergy : ICardEffect
    {
        public int energyRestoreAmount;
        public void Process()
        {
            CardEffectProcessor.Instance.RestoreEnergy(energyRestoreAmount);
        }
    }
}

