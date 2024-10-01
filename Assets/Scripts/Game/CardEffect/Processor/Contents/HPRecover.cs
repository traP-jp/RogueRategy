using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    [System.Serializable]
    public class HPRecoverProcessor : ICardEffectProcessor
    {
        public int recoverValue;
        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            usersStatus.HPChange(recoverValue);
        }
    }
}

