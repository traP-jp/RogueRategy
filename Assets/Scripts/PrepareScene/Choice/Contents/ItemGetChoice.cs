using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class ItemGetChoice : MonoBehaviour,IChoice
    {
        public Item rewardItem;
        public void Process(OnFinish onFinish,PlayersInfo playersInfo) 
        {
            Debug.Log("アイテムをゲットしたよ!!");
            for(int i = 0; i < playersInfo.playersItem.Count; i++)
            {
                if (playersInfo.playersItem[i] == null)
                {
                    playersInfo.playersItem[i] = rewardItem;
                    break;
                }
            }
            onFinish();//これはItemGetの処理が完全に終わったタイミングで呼び出す
        }

        public string GetExplanationText()
        {
            return "アイテム:" +rewardItem.itemName+"を獲得する";
        }
    }

}
