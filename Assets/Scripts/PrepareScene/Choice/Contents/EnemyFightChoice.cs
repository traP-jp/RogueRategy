using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PrepareSceneOnly
{
    public class EnemyFightChoice : MonoBehaviour,IChoice
    {
        public void Process(OnFinish onFinish,PlayersInfo playersInfo)
        {
            string sceneName = SceneManager.GetActiveScene().name.Replace("Prepare","Battle");
            SceneManager.LoadScene(sceneName);
            onFinish();
        }
        public string GetExplanationText()
        {
            return "敵と戦闘する";
        }

        public int ProgressAmount()
        {
            return 5;
        }
    }
}

