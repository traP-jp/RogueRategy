using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    [System.Serializable]
    public class CardEffectBundle : ICardEffectBundle
    {
        //カードの効果が複数あるのを一つにまとめたもの
        [SerializeReference,SubclassSelector]public ICardEffect[] cardEffectArray;

        public void Process(StatusBase usersStatus,Vector2 usersPos)
        {
            for(int i = 0; i < cardEffectArray.Length; i++)
            {
                cardEffectArray[i].Process(usersStatus,usersPos);//カードエフェクトをバンドルに入っているものを上から実行する
            }
        }


    }
    public interface ICardEffectBundle
    {
        void Process(StatusBase usersStatus,Vector2 usersPos);
    }
    public interface ICardEffect
    {
        void Process(StatusBase usersStatus,Vector2 usersPos);
    }
}
