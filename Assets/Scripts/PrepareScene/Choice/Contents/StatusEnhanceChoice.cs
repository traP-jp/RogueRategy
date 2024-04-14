using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class StatusEnhanceChoice : MonoBehaviour, IChoice
    {
        public void Process(OnFinish onFinish,PlayersInfo playersInfo)
        {
            //この選択肢は使わない方針で行きます
            playersInfo.attack += 10;//仮置きでプレイヤーのアタック+10としている　　実際は動的に様々な強化内容が設定できるようにしたい
            onFinish();
        }

        public string GetExplanationText()
        {
            return "攻撃力を10増加させる";
        }
    }
}

