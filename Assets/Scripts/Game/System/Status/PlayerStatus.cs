using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;
using BuffTypeInspector;
public class PlayerStatus : StatusBase
{
    private void Awake()
    {
        base.Awake();
        unitAttackRatio = 1;
        unitDefenseRatio = 1;
        unitSpeedRatio = 1;
        resultUnitAttack = unitAttack;
        resultUnitDefense = unitDefense;
        resultUnitSpeed = unitSpeed;
    }
    //デフォルト値
    public float unitAttack;//プレイヤーが出すユニットに反映される攻撃力,attackと統合しても良いがいつでも分けられるように分けておく
    public float unitDefense;
    public float unitSpeed;
    //バフなどで変動する倍率
    public float unitAttackRatio;
    public float unitDefenseRatio;
    public float unitSpeedRatio;
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
        unitAttackRatio = 1;
        unitDefenseRatio = 1;
        unitSpeedRatio = 1;
        costDiffAmount = 0;
        isControllReverse = false;
        //Ratio値の更新
        foreach(BuffCore buffCore in buffCores)
        {
            buffCore.Process(this);
        }
        //現在の値の更新
        resultAttack = attack * attackRatio;
        resultDefense = defense * defenseRatio;
        resultSpeed = speed * speedRatio;
        resultUnitAttack = unitAttack * unitAttackRatio;
        resultUnitDefense = unitDefense * unitDefenseRatio;
        resultUnitSpeed = unitSpeed * unitSpeedRatio;

    }
}
