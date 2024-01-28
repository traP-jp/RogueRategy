using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpeedChange : BuffCore
{
    public float speedRatio;
   public override void Process(StatusBase statusBase)
   {
        statusBase.speedRatio *= speedRatio;
   }
}
