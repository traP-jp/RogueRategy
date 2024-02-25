using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class CardGetChoice : MonoBehaviour,IChoice
    {
        public CardInfo rewardCard;

        public string GetExplanationText()
        {
            return rewardCard.cardName + "を獲得する";
        }

        public void Process(OnFinish onFinish)
        {
            onFinish();
        }
    }
}
