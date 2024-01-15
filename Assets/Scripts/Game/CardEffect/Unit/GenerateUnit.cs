using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect//カードの効果はこの名前空間に入れる
{
    [System.Serializable]
    public class GenerateUnit : ICardEffect
    {
        //この辺でどのユニットをどこに出すかを指定
        [SerializeField] GameObject unitObject;
        public void Process()
        {
            //Instantiate(unitObject, playerTransform.position, Quaternion.identity, parentTransform);
            Debug.Log("発射");
        }
    }
}

