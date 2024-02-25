using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class ItemGetChoice : MonoBehaviour,IChoice
    {
        public void Process(OnFinish onFinish) 
        {
            Debug.Log("アイテムをゲットしたよ!!");
            onFinish();//これはItemGetの処理が完全に終わったタイミングで呼び出す
        }

        public string GetExplanationText()
        {
            return "アイテムを獲得する";
        }
    }

}
