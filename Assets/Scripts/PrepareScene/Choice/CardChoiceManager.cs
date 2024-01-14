using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    public delegate void OnFinish();

    public class CardChoiceManager : MonoBehaviour
    {
        OnFinish onFinish;
        private void Start()
        {
            //選択終了時にcalledWhenProcessFinishedを呼び出す
            onFinish = CalledWhenProcessFinished;
        }

        IChoice[] choiceArray = new IChoice[3];
        public void ChooseChoice(int choiceNumber)
        {
            //3択の選択肢のどれかを選んだときに呼び出される
            //一番左のを選んだ時はchoiceNumber=0,真ん中は1,右は2
            choiceArray[choiceNumber].Process(onFinish);
        }

        void CalledWhenProcessFinished()
        {
            //選択終了時に呼び出される
            SelectNextChoice();//次の選択肢を選ぶ

        }

        void SelectNextChoice()
        {

        }
    }

    public interface IChoice
    {
        //選択肢を表すスクリプトにはこのインターフェイスをつける
        void Process(OnFinish onFinish);//クリックされたときはこの関数を呼ぶ
    }
}

