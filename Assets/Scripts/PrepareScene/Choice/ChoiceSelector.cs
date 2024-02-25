using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrepareSceneOnly
{
    public class ChoiceSelector : MonoBehaviour
    {
        [SerializeField] CardInfo[] cardList;//カードを手にいれる選択肢で手に入るカードのリストをこれに設定し、このスクリプト内で乱数でゲット
                                         //いつかこれにレアリティ的な概念を入れて、カードのレア度に差をつけたい


        public IChoice[] GetChoices(int length)
        {
            IChoice[] resultChoices = new IChoice[length];

            for(int i = 0; i < length; i++)
            {
                //仮置きとして各選択肢に対しランダムで休憩、カード取得、敵と戦闘、アイテム取得の中から選ぶ
                switch (Random.Range(0, 5))
                {
                    case 0:
                        resultChoices[i] = GenerateRestChoice();
                        break;
                    case 1:
                        resultChoices[i] = GenerateCardGetChoice();
                        break;
                    case 2:
                        resultChoices[i] = GenerateEnemyFightChoice();
                        break;
                    case 3:
                        resultChoices[i] = GenerateItemGetChoice();
                        break;
                    case 4:
                        resultChoices[i] = GenerateStatusEnhanceChoice();
                        break;
                }
            }

            return resultChoices;
        }

        IChoice GenerateRestChoice()
        {
            RestChoice restChoice = new RestChoice();
            restChoice.recoverAmount = 10;//仮置き
            return restChoice;
        }

        IChoice GenerateCardGetChoice()
        {
            CardGetChoice cardGetChoice = new CardGetChoice();
            cardGetChoice.rewardCard = cardList[Random.Range(0, cardList.Length)];
            return cardGetChoice;
        }

        IChoice GenerateEnemyFightChoice()
        {
            EnemyFightChoice enemyFightChoice = new EnemyFightChoice();
            //敵の実装の仕方によりますが、StageっていうScriptableオブジェクトを作成し、そこにステージ情報を保存するのがいいかなー
            //そして、そのStageをランダムで決定する感じ
            return enemyFightChoice;
        }

        IChoice GenerateItemGetChoice()
        {
            ItemGetChoice itemGetChoice = new ItemGetChoice();
            //アイテム周りの処理は作成していないので仮置き
            return itemGetChoice;
        }

        IChoice GenerateStatusEnhanceChoice()
        {
            StatusEnhanceChoice statusEnhanceChoice = new StatusEnhanceChoice();
            return statusEnhanceChoice;
        }
    }
}

