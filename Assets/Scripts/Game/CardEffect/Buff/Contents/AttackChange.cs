using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AttackChange : BuffCore
{
    public float attackRatio;
    public override void Process(StatusBase statusBase)
    {
        statusBase.attackRatio *= attackRatio;
    }
}
