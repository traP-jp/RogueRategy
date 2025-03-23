using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Card;
using TMPro;

namespace Game.UI
{
    public class DeckCardSelect : MonoBehaviour
    {
        public void SetCardInfo(CardInfo cardInfo)
        {
            // カードの情報をセットする処理
            cardNameText.text = cardInfo.CardName;
        }

        [SerializeField] TextMeshProUGUI cardNameText;
    }
}