using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;
using BuffTypeInspector;
public class PlayerStatus : StatusBase
{
    //現在の特殊な状態
    public int costDiffAmount;//カードのコストの変化、1なら2コストのカードが3コストかかる
    public bool isControllReverse;
    //現在の値
    public float resultUnitAttack;
    public float resultUnitDefense;
    public float resultUnitSpeed;

    public override void PermanentBuffUpdate(BuffCore[] buffCores)
    {
        //初期化
        attackRatio = 1;
        defenseRatio = 1;
        speedRatio = 1;
        bulletSpeedRatio = 1;
        costDiffAmount = 0;
        isControllReverse = false;
        //Ratio値の更新
        foreach(BuffCore buffCore in buffCores)
        {
            if (buffCore.IsBuffSubjectPlayer())
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
