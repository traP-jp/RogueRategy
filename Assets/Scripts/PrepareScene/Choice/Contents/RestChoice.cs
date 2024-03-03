using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class RestChoice : MonoBehaviour,IChoice
    {
        public float recoverAmount;//回復量を表す。HPがfloat型なのでfloat型だが、表記するときは見栄えから整数で表記するかも?
        public void Process(OnFinish onFinish,PlayersInfo playersInfo)
        {
            playersInfo.nowHP = Mathf.Min(playersInfo.nowHP + recoverAmount,playersInfo.maxHP);
            onFinish();
        }

        public string GetExplanationText()
        {
            return "休憩してHPを" + recoverAmount + "回復する";
        }
    }
}

