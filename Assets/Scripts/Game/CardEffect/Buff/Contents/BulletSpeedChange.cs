using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BulletSpeedChange : BuffCore
{
    public float bulletSpeedRatio;
    public override void Process(StatusBase statusBase)
    {
        statusBase.bulletSpeedRatio *= bulletSpeedRatio;
    }
}
