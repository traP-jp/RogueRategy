using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using Cysharp.Threading.Tasks;
using Game.Card;

namespace Game.UI
{
    public class DeckCardSelects : MonoBehaviour
    {
        [SerializeField] DeckCardSelect deckCardSelectPrefab;
        [SerializeField] Transform selectCursor;
        [SerializeField] Vector3 startPos;
        [SerializeField] Vector3 endPos;
        [SerializeField] int cardNum = 8;

        private int selectIndex = 0;
        private bool isHolding = false;
        private List<DeckCardSelect> deckCardSelects = new List<DeckCardSelect>();
        private float yInterval;
        private List<CardInfo> cardInfoList;

        public void SetCardInfoList(List<CardInfo> cardInfoList)
        {
            this.cardInfoList = cardInfoList;
            yInterval = -1*(endPos.y - startPos.y) / cardNum;

            for (int i = 0; i < cardInfoList.Count; i++)
            {
                var deckCardSelect = Instantiate(deckCardSelectPrefab, transform);
                deckCardSelect.SetCardInfo(cardInfoList[i]);
                deckCardSelects.Add(deckCardSelect);
                deckCardSelect.transform.localPosition = startPos + new Vector3(0, -yInterval * i, 0);
                selectCursor.position = new Vector3(selectCursor.position.x, startPos.y, selectCursor.position.z);
            }

            selectCursor.localPosition = new Vector3(selectCursor.localPosition.x, startPos.y - yInterval * selectIndex, selectCursor.localPosition.z);
        }

        public void SetSelectIndex(bool isSelected)
        {
            if (isSelected)
            {
                // 選択されたカードをDotweenで少し右にずらす
                deckCardSelects[selectIndex].transform.DOLocalMoveX(20, 0.1f);
                selectCursor.gameObject.SetActive(false);
                isHolding = true;
            }
            else
            {
                deckCardSelects[selectIndex].transform.DOLocalMoveX(0, 0.1f);
                selectCursor.gameObject.SetActive(true);
                isHolding = false;
            }
        }

        // 上ボタンを押した時の処理
        public void OnUpButton()
        {
            if (selectIndex > 0)
            {
                MoveSelectIndex(-1);
            }
        }

        // 下ボタンを押した時の処理
        public void OnDownButton()
        {
            if (selectIndex < deckCardSelects.Count - 1)
            {
                MoveSelectIndex(1);
            }
        }

        private void MoveSelectIndex(int direction)
        {
            var prevIndex = selectIndex;
            selectIndex += direction;
            selectCursor.localPosition = new Vector3(selectCursor.localPosition.x, startPos.y - yInterval * selectIndex, selectCursor.localPosition.z);
            if (isHolding)
            {
                var newCard = deckCardSelects[selectIndex];
                var prevCard = deckCardSelects[prevIndex];
                newCard.transform.DOLocalMoveY(newCard.transform.localPosition.y + yInterval * direction, 0.1f);
                prevCard.transform.DOLocalMoveY(prevCard.transform.localPosition.y - yInterval * direction, 0.1f);

                deckCardSelects[prevIndex] = newCard;
                deckCardSelects[selectIndex] = prevCard;

                var temp = cardInfoList[prevIndex];
                cardInfoList[prevIndex] = cardInfoList[selectIndex];
                cardInfoList[selectIndex] = temp;
            }
        }
    }
}
