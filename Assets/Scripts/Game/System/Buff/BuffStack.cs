using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BuffTypeInspector;
using System;
public class BuffStack : MonoBehaviour,CardEffect.IBuffable
{
    List<BuffCore> nowBuffList = new List<BuffCore>();//全てのバフのリスト
    List<(BuffCore,float)> nowBuffDictionaryWithTimeLimit = new List<(BuffCore, float)>();//今のタイムリミット付きバフが入る
    List<(BuffCore, int)> nowBuffDictionaryWithCardCountLimit = new List<(BuffCore, int)>();//今のカードカウント制限付きバフが入る                                                                                             

    private void Start()
    {
        BuffManager.Instance.SubscribeBuffStack(this);
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
            nowBuffDictionaryWithCardCountLimit.Add((buffCore, lcc.limitCardCount));
        }
    }

    private void Update()
    {
        UpdateLeftTime();
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
                nowBuffList.Remove(pair.Item1);
            }
            else
            {
                nowBuffDictionaryWithTimeLimit[i] = (pair.Item1, updatedLeftTime);
            }
        }
        while (deleteIndexes.Count > 0)
        {
            nowBuffDictionaryWithTimeLimit.RemoveAt(deleteIndexes.Pop());
        }
    }

    public void NoticeCardUse()
    {
        //カードを使用した時にBuffManagerが自動的に呼び出し、カード使用回数制限があるバフを更新する
        Stack<int> deleteIndexes = new Stack<int>();
        for (int i = 0; i < nowBuffDictionaryWithCardCountLimit.Count; i++)
        {
            //時間制限付きバフの時間制限の更新
            var pair = nowBuffDictionaryWithCardCountLimit[i];
            int updatedCardCount = pair.Item2 - 1;
            if (updatedCardCount <= 0)
            {
                deleteIndexes.Push(i);
                nowBuffList.Remove(pair.Item1);
            }
            else
            {
                nowBuffDictionaryWithTimeLimit[i] = (pair.Item1,updatedCardCount);
            }
        }
        while (deleteIndexes.Count > 0)
        {
            nowBuffDictionaryWithTimeLimit.RemoveAt(deleteIndexes.Pop());
        }

    }
}
