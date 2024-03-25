using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffTypeInspector;
using System;
public class BuffStack : MonoBehaviour,CardEffect.IBuffable
{
    [SerializeField]bool isPlayersBuffStack = false;//プレイヤーに付けられているバフスタックならtrue、ユニットにつけられているならfalse
    [SerializeField] int debugInt;

    List<BuffCore> nowBuffList = new List<BuffCore>();//全てのバフのリスト
    List<(BuffCore,float)> nowBuffDictionaryWithTimeLimit = new List<(BuffCore, float)>();//今のタイムリミット付きバフが入る
    List<(BuffCore, int)> nowBuffDictionaryWithCardCountLimit = new List<(BuffCore, int)>();//今のカードカウント制限付きバフが入る                                                                                             

    List<(BuffCore, float)> nowBuffWithActivateAtInterval = new List<(BuffCore, float)>();
    List<BuffCore> nowBuffWithActivatePermanently = new List<BuffCore>();
    List<BuffCore> nowBuffWithActivateOnCardUse = new List<BuffCore>();

    [SerializeField]StatusBase connectedStatusBase;
    private void Start()
    {
        BuffManager.Instance.SubscribeBuffStack(this);
    }

    private void Reset()
    {
        connectedStatusBase = GetComponent<StatusBase>();
    }

    public void AddBuff(BuffCore buffCore)
    {
        //タイプ分けしてリストに登録
        nowBuffList.Add(buffCore);
        Type buffTypesType = buffCore.GetBufftype().GetType();
        if(buffTypesType == typeof(LimitedTime))
        {
            LimitedTime lt = (LimitedTime)buffCore.GetBufftype();
            nowBuffDictionaryWithTimeLimit.Add((buffCore, lt.durationTime));
        }
        else if(buffTypesType == typeof(LimitedCardCount))
        {
            LimitedCardCount lcc = (LimitedCardCount)buffCore.GetBufftype();
            nowBuffDictionaryWithCardCountLimit.Add((buffCore, lcc.limitCardCount + 1));
        }

        Type buffWhenActivateType = buffCore.GetBuffWhenActivate().GetType();
        if(buffWhenActivateType == typeof(AtInterval))
        {
            AtInterval atInterval = (AtInterval)buffCore.GetBuffWhenActivate();
            nowBuffWithActivateAtInterval.Add((buffCore, atInterval.intervalTime));
        }
        else if(buffWhenActivateType == typeof(OnCardUse))
        {
            nowBuffWithActivateOnCardUse.Add(buffCore);
        }
        else if(buffWhenActivateType == typeof(Permanently))
        {
            //プレイヤークラスに状態異常の更新をするような通知を行う
            nowBuffWithActivatePermanently.Add(buffCore);
            connectedStatusBase.PermanentBuffUpdate(nowBuffWithActivatePermanently.ToArray());
        }
    }

    public BuffCore[] GetNowBuffCoreArray()
    {
        return nowBuffList.ToArray();
    }
    public void RemoveAllBuff()
    {
        //全てのバフを削除
        foreach(BuffCore bc in nowBuffList)
        {
            RemoveBuff(bc);
        }
    }
    public void RemoveBuff(BuffCore buffCore)
    {
        //バフを取り除く
        nowBuffList.Remove(buffCore);
        RemoveOneItem1Tuple(buffCore, nowBuffDictionaryWithTimeLimit);
        RemoveOneItem1Tuple(buffCore, nowBuffDictionaryWithCardCountLimit);
        RemoveOneItem1Tuple(buffCore, nowBuffWithActivateAtInterval);
        nowBuffWithActivatePermanently.Remove(buffCore);
        nowBuffWithActivatePermanently.Remove(buffCore);
        if(buffCore.GetBuffWhenActivate().GetType() == typeof(Permanently))
        {
            //プレイヤークラスに状態異常の更新をするような通知を行う
            connectedStatusBase.PermanentBuffUpdate(nowBuffWithActivatePermanently.ToArray());
        }
    }
    public void RemoveOneItem1Tuple<T,V>(T deleteKey,List<(T,V)> deleteList)
    {
        //タプルを要素にもつリストのItem1が一致するものを一つだけ消す
        int deleteIndex = -1;
        for(int i = 0; i < deleteList.Count; i++)
        {
            if (deleteList[i].Item1.Equals(deleteKey))
            {
                deleteIndex = i;
                break;
            }
        }
        if(deleteIndex >= 0)
        {
            deleteList.RemoveAt(deleteIndex);
        }
    }
    private void Update()
    {
        UpdateLeftTime();
        UpdateInterval();
        debugInt = nowBuffWithActivatePermanently.Count;
    }

    void UpdateLeftTime()
    {
        float deltaTime = Time.deltaTime;
        Stack<int> deleteIndexes = new Stack<int>();

        for(int i = 0;i<nowBuffDictionaryWithTimeLimit.Count;i++)
        {
            //時間制限付きバフの時間制限の更新
            var pair = nowBuffDictionaryWithTimeLimit[i];
            float updatedLeftTime = pair.Item2 - deltaTime;
            if(updatedLeftTime <= 0)
            {
                deleteIndexes.Push(i);
            }
            else
            {
                nowBuffDictionaryWithTimeLimit[i] = (pair.Item1, updatedLeftTime);
            }
        }
        while (deleteIndexes.Count > 0)
        {
            RemoveBuff(nowBuffDictionaryWithTimeLimit[deleteIndexes.Pop()].Item1);
        }
    }
    void UpdateInterval()
    {
        //一定時間おきに発動するバフの起動を行う
        for(int i = 0;i<nowBuffWithActivateAtInterval.Count;i++)
        {
            var pair = nowBuffWithActivateAtInterval[i];
            float leftTime = pair.Item2 - Time.deltaTime;
            if(leftTime <= 0)
            {
                //バフ効果を発動してインターバルタイムを復活
                BuffCore bc = pair.Item1;
                //bc.Process(connectedStatusBase);
                ProcessBuffEffect(bc, connectedStatusBase);
                float intervalTime = ((AtInterval)bc.GetBuffWhenActivate()).intervalTime;//バフのインターバルタイムを取得
                leftTime += intervalTime;
            }
            nowBuffWithActivateAtInterval[i] = (pair.Item1, leftTime);

        }
    }

    public void ProcessBuffEffect(BuffCore bc,StatusBase statusBase)
    {
        if (isPlayersBuffStack && (bc.IsBuffSubjectPlayer() || bc.buffSubject == BuffSubjectEntity.MyselfButCantConvey)) bc.Process(statusBase);//プレイヤーのBuffStackならバフの対象がプレイヤーなら発動する
        if (!isPlayersBuffStack && (bc.IsBuffSubjectAllyUnit() || bc.buffSubject == BuffSubjectEntity.MyselfButCantConvey)) bc.Process(statusBase);//ユニットのBuffStackならバフの対象がユニット自身なら発動する
    }

    public void NoticeCardUse()
    {
        //カードを使用した時にBuffManagerが自動的に呼び出す。
        //カードが使用された時に効果発動するバフの処理を行う
        foreach (BuffCore bc in nowBuffWithActivateOnCardUse)
        {
            //bc.Process(connectedStatusBase);
            ProcessBuffEffect(bc, connectedStatusBase);
        }
        //カード使用回数制限があるバフを更新する
        Stack<int> deleteIndexes = new Stack<int>();
        for (int i = 0; i < nowBuffDictionaryWithCardCountLimit.Count; i++)
        {
            //時間制限付きバフの時間制限の更新
            var pair = nowBuffDictionaryWithCardCountLimit[i];
            int updatedCardCount = pair.Item2 - 1;
            if (updatedCardCount <= 0)
            {
               
                deleteIndexes.Push(i);
            }
            else
            {
                nowBuffDictionaryWithCardCountLimit[i] = (pair.Item1,updatedCardCount);
            }
        }
        while (deleteIndexes.Count > 0)
        {
            RemoveBuff(nowBuffDictionaryWithCardCountLimit[deleteIndexes.Pop()].Item1);
        }

    }
}
