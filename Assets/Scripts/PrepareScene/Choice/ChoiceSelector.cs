using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrepareSceneOnly
{
    public class ChoiceSelector : MonoBehaviour
    {
        [SerializeField] RandomTable<Item> rewardItemTable;
        [SerializeField] RandomTable<CardInfo> rewardCardTable;

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
                        resultChoices[i] = GenerateRandomEventChoice();
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
            cardGetChoice.rewardCard = rewardCardTable.GetRandomData();
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
            itemGetChoice.rewardItem = rewardItemTable.GetRandomData();
            return itemGetChoice;
        }

        IChoice GenerateStatusEnhanceChoice()
        {
            StatusEnhanceChoice statusEnhanceChoice = new StatusEnhanceChoice();
            return statusEnhanceChoice;
        }

        IChoice GenerateRandomEventChoice()
        {
            RandomEventChoice randomEventChoice = new RandomEventChoice();
            return randomEventChoice;
        }
    }
}

