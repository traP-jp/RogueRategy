using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Burning : BuffCore
{
    public float Intensity;

    public override void Process(StatusBase statusBase)
    {
        statusBase.HP -= Intensity;
        EffectDepictor.Instance.DepictEffect(Info.Instance.enemyTransform.position, "Refresh");
    }
}
