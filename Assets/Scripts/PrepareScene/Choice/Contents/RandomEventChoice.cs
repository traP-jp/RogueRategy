using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrepareSceneOnly
{
    public class RandomEventChoice : MonoBehaviour,IChoice
{
        public string GetExplanationText()
        {
            return "何が起こるかわからない";
        }

        public void Process(OnFinish onFinish, PlayersInfo playersInfo)
        {
            onFinish();
        }
    }
}

