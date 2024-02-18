using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusBase : MonoBehaviour
{
    protected void Awake()
    {
        attackRatio = 1;
        defenseRatio = 1;
        speedRatio = 1;
        resultAttack = attack;
        resultDefense = defense;
        resultSpeed = speed;
    }



    [SerializeField] BuffStack connectedBuffStack;
    //デフォルトの戦闘中は不変の値
    public float MaxHP;
    public float attack; //デフォルトの攻撃力
    public float defense;//必要かどうか議論の余地あり
    public float speed;
    //現在の値。常に手動で更新
    public float HP;//今はPlayerManagerにHPの情報が置いてあるがいつかこっちに移す
    public float resultAttack;
    public float resultDefense;
    public float resultSpeed;
    //バフによる倍率など
    public float attackRatio;//バフの効果により上乗せされている倍率
    public float defenseRatio;
    public float speedRatio;

    public abstract void PermanentBuffUpdate(BuffCore[] buffCores);

    private void Start()
    {
        //BuffStackとの相互参照
        connectedBuffStack.NoticeStatusBase(this);
    }
}
