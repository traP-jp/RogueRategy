using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardEffect;
public class PlayerBuffManagement : MonoBehaviour,IBuffable
{
    List<BuffCore> nowBuffList = new List<BuffCore>();//プレイヤーが今持っている状態異常をリストにする
    public void AddBuff(BuffCore buff)
    {
        nowBuffList.Add(buff);
    }
}
