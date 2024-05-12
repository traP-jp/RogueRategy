using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
namespace PrepareSceneOnly
{
    public delegate void OnFinish();
    [RequireComponent(typeof(ChoiceSelector))]
    public class CardChoiceManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI[] choiceExplanationTexts;//選択肢ごとに設定された説明文
        [SerializeField] TextMeshProUGUI[] progressTexts;//選択肢ごとに設定された進行度の量を示す文章
        [SerializeField] TextMeshProUGUI progressRateText;//現在のプレイヤーの進行度を表す
        [SerializeField] TextMeshProUGUI moneyAmountText;//現在のお金の量を表す
        [SerializeField] PlayersInfo playersInfo;
        
        ChoiceSelector choiceSelector;
        OnFinish onFinish;

        ReactiveProperty<int> progressRate = new ReactiveProperty<int>();//進行度、これがある程度貯まるとボス戦が始まる
        ReactiveProperty<int> moneyAmount = new ReactiveProperty<int>();//持っているお金の量

        private void Awake()
        {
            choiceSelector = GetComponent<ChoiceSelector>();
        }
        private void Start()
        { 
            //選択終了時にcalledWhenProcessFinishedを呼び出す
            onFinish = CalledWhenProcessFinished;
            SelectNextChoice();
            DepictChoiceText();

            //初期化
            progressRate.Value = playersInfo.progressRate;
            moneyAmount.Value = playersInfo.money;
            //進行度やお金の量が変化したとき、テキストを変化させる
            progressRate.Subscribe(x => progressRateText.text = x.ToString()).AddTo(this);
            progressRate.Subscribe(x => playersInfo.progressRate = x);
            moneyAmount.Subscribe(x => moneyAmountText.text = x.ToString()).AddTo(this);
            moneyAmount.Subscribe(x => playersInfo.money = x);


        }

        IChoice[] choiceArray = new IChoice[3];
        public void ChooseChoice(int choiceNumber)
        {
            //3択の選択肢のどれかを選んだときに呼び出される
            //進行度を増やす
            progressRate.Value += choiceArray[choiceNumber].ProgressAmount();
            //一番左のを選んだ時はchoiceNumber=0,真ん中は1,右は2
            choiceArray[choiceNumber].Process(onFinish,playersInfo);
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
            //選択肢の描画を行う
            if(choiceExplanationTexts.Length == choiceArray.Length)
            {
                for(int i = 0; i < choiceExplanationTexts.Length; i++)
                {
                    //説明文の描画
                    choiceExplanationTexts[i].text = choiceArray[i].GetExplanationText();
                    //進行度増加分の描画
                    progressTexts[i].text = choiceArray[i].ProgressAmount().ToString();
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
        void Process(OnFinish onFinish,PlayersInfo playersInfo);//クリックされたときはこの関数を呼ぶ

        string GetExplanationText();
        int ProgressAmount();
    }
}

