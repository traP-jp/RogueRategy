using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;
using BuffTypeInspector;
public class PlayerStatus : StatusBase
{
    
    public float unitAttack { get; }//プレイヤーが出すユニットに反映される攻撃力,attackと統合しても良いがいつでも分けられるように分けておく
    public float unitDefense { get; }
    public float unitSpeed { get; }
    
    public float unitAttackRatio { get; set; }
    public float unitDefenseRatio { get; set; }
    public float unitSpeedRatio { get; set; }

    public int costDiffAmount { get; set; }//カードのコストの変化、1なら2コストのカードが3コストかかる
    public bool isControllReverse { get; set; }
    

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
        //値の更新
        foreach(BuffCore buffCore in buffCores)
        {
            buffCore.Process(this);
        }

    }
}
