using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;

[System.Serializable]
public class HPRecover : ICardEffect
{
    public int recoverValue;
    public void Process()
    {
        CardEffectProcessor.Instance.RecoverPlayerHP(recoverValue);
    }
}
