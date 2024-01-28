using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CostChange : BuffCore
{
    public int changeAmount;
    public override void Process(StatusBase statusBase)
    {
        ((PlayerStatus)statusBase).costDiffAmount += changeAmount;
        
    }
}
