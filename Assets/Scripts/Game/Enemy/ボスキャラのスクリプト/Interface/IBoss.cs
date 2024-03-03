using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossPart
{
    //ミサイルの発射処理
    void ShotMissile(int missileNum,int missilePortNum,bool isObjectParent);

    //やられた時の演出
    void BrokenEffect();
}
