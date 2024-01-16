using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public class EnemyFightChoice : MonoBehaviour,IChoice
    {
        public void Process(OnFinish onFinish)
        {
            onFinish();
        }
    }
}

