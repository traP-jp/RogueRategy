using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;
public class PlayerBuffManagement : MonoBehaviour,IBuffable
{
    List<IBuff> nowBuffList = new List<IBuff>();//プレイヤーが今持っている状態異常をリストにする
    public void AddBuff(IBuff buff)
    {
        nowBuffList.Add(buff);
    }
}
