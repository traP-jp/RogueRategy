using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DefenseChange : BuffCore
{
    public float defenseRatio;
    public override void Process(StatusBase statusBase)
    {
        statusBase.defenseRatio *= defenseRatio;
    }
}
