using Game.Player;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class CardCostDownProcessor : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;

        public void Process(int cardCount ,float ratio, int downAmount, int maxCost)
        {
            for (int i = 0; i < cardCount; i++)
            {
                int nowCost = _playerInfo.NowDeck[i + 1].Cost;
                if (nowCost <= maxCost)
                {
                    int resultCost = Mathf.FloorToInt(nowCost * ratio) - downAmount;
                    resultCost = Mathf.Max(0, resultCost);
                    _playerInfo.NowDeck[i + 1].Cost = resultCost;   
                }
            }
        }
    }
}