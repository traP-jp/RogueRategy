using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusBase : MonoBehaviour
{

    [SerializeField] BuffStack connectedBuffStack;
    public float HP;//今はPlayerManagerにHPの情報が置いてあるがいつかこっちに移す
    public float attack { get; }//デフォルトの攻撃力
    public float defense { get; }//必要かどうか議論の余地あり
    public float speed { get; }

    public float attackRatio { get; set; }//バフの効果により上乗せされている倍率
    public float defenseRatio { get; set; }
    public float speedRatio { get; set; }

    public abstract void PermanentBuffUpdate(BuffCore[] buffCores);

    private void Start()
    {
        //BuffStackとの相互参照
        connectedBuffStack.NoticeStatusBase(this);
    }
}
