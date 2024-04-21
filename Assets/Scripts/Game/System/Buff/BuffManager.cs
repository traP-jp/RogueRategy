using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : SingletonMonoBehaviour<BuffManager>
{
    /// <summary>
    /// このクラスではバフの管理を行う
    /// 具体的にはバフの登録、効果の発動指令などの処理
    /// 各ユニット、プレイヤーについたBuffStackクラスへの情報伝達も行う
    /// </summary>
    List<BuffStack> buffStackList = new List<BuffStack>();

    [SerializeField] BuffStack playerBuffStack;

    public void SubscribeBuffStack(BuffStack buffStack)
    {
        buffStackList.Add(buffStack);
    }

    public void NoticeCardUse()
    {
        foreach(BuffStack bs in buffStackList)
        {
            bs.NoticeCardUse();
        }
    }
}


