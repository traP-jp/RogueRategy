using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : SingletonMonoBehaviour<BuffManager>
{
    /// <summary>
    /// このクラスではバフの管理を行う
    /// 具体的にはバフの登録、効果の発動指令、バフの時間制限などの処理
    /// 各ユニット、プレイヤーについたBuffStackクラスへの情報伝達も行う
    /// </summary>
    // Update is called once per frame

    [SerializeField] BuffStack playerBuffStack;
    public void AddBuffToPlayer(BuffCore buffCore)
    {
        playerBuffStack.AddBuff(buffCore);
    }
    void Update()
    {
        
    }
}


