using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    
    //ユニットの各要素へのアクセスを統括する(バフ、移動、攻撃)
    public BuffStack unitBuffStack;
    public UnitStatus unitStatus;
    public bool isPlayerSide;//プレイヤーが出したユニットだったらこれをtrueにする。この情報を元に行動パターンなどを作る
    private void Reset()
    {
        unitBuffStack = GetComponent<BuffStack>();
        unitStatus = GetComponent<UnitStatus>();
    }

    public void ConveyBuffToBullet(BulletManager bulletManager)
    {
        foreach (BuffCore bc in unitBuffStack.GetNowBuffCoreArray())
        {
            if (bc.IsBuffSubjectOpponentUnit())
            {
                bulletManager.bulletsBuffList.Add(bc);
            }
        }
    }
}
