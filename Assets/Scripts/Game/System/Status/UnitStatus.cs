using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatus : StatusBase
{

    private void Reset()
    {
        base.Reset();
    }

    public override void PermanentBuffUpdate(BuffCore[] buffCores)
    {
        //初期化
        attackRatio = 1;
        defenseRatio = 1;
        speedRatio = 1;
        bulletSpeedRatio = 1;
        //Ratio値の更新
        foreach (BuffCore buffCore in buffCores)
        {
            if (buffCore.IsBuffSubjectAllyUnit())
            {
                buffCore.Process(this);
            }
        }
        //現在の値の更新
        resultAttack = attack * attackRatio;
        resultDefense = defense * defenseRatio;
        resultSpeed = speed * speedRatio;
        resultBulletSpeed = bulletSpeed * bulletSpeedRatio;
    }
}