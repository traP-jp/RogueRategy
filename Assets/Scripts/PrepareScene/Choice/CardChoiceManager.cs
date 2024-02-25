using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace PrepareSceneOnly
{
    public delegate void OnFinish();
    [RequireComponent(typeof(ChoiceSelector))]
    public class CardChoiceManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] choiceExplanationTexts;
        ChoiceSelector choiceSelector;
        OnFinish onFinish;

        private void Awake()
        {
            choiceSelector.GetComponent<ChoiceSelector>();
        }
        private void Start()
        {
            //選択終了時にcalledWhenProcessFinishedを呼び出す
            onFinish = CalledWhenProcessFinished;

            SelectNextChoice();
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
            DepictChoiceText();//選択肢の説明文の描画
        }

        void SelectNextChoice()
        {
           choiceArray =  choiceSelector.GetChoices(3);
        }

        void DepictChoiceText()
        {
            if(choiceExplanationTexts.Length == choiceArray.Length)
            {
                for(int i = 0; i < choiceExplanationTexts.Length; i++)
                {
                    choiceExplanationTexts[i].text = choiceArray[i].GetExplanationText();
                }
            }
            else
            {
                Debug.Log("エラー：配列の大きさが異なります");
            }
        }
    }

    public interface IChoice
    {
        //選択肢を表すスクリプトにはこのインターフェイスをつける
        void Process(OnFinish onFinish);//クリックされたときはこの関数を呼ぶ

        string GetExplanationText();
    }
}

