using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CardEffect//カードの効果はこの名前空間に入れる
{
    [System.Serializable]
    public class GenerateUnit : ICard
    {
        //この辺でどのユニットをどこに出すかを指定
        //parentTransformやplayerTransformは指定せずに入力されるようにしたい
        [SerializeField] GameObject unitObject;
        [SerializeField] Transform parentTransform;
        [SerializeField] Transform playerTransform;
        public void Process()
        {
            //Instantiate(unitObject, playerTransform.position, Quaternion.identity, parentTransform);
        }
    }
}

