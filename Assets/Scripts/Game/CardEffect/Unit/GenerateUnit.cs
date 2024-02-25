using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect//カードの効果はこの名前空間に入れる
{
    [System.Serializable]
    public class GenerateUnit : ICardEffect
    {
        //この辺でどのユニットをどこに出すかを指定
        [SerializeField] UnitManager unitObject;
        public void Process()
        {
            CardEffectProcessor.Instance.GenerateUnitOnPlayer(unitObject);
        }
    }
}

