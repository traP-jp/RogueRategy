using System;
using System.Collections.Generic;
using DG.Tweening;
using Game.Card;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Card
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] int _displayCardCount = 4;
        [SerializeField] RectTransform _bottomOrigin;
        [SerializeField] Image _cardPrefab;
        RectTransform[] _cardRectTransforms;
        readonly List<Tweener> _movingTweener = new List<Tweener>();

        public void InitializeCardDeck(CardInfo[] cardInfos)
        {
            _cardRectTransforms = new RectTransform[_displayCardCount];
            for (int i = 0; i < _displayCardCount; i++)
            {
                Image cardImage = Instantiate(_cardPrefab, transform);
                cardImage.sprite = cardInfos[i % cardInfos.Length].CardImage;
                _cardRectTransforms[i] = cardImage.GetComponent<RectTransform>();
                _cardRectTransforms[i].anchoredPosition = _bottomOrigin.anchoredPosition + Vector2.up * i * 280;
            }
        }

        public void OnUseBottomCard(CardInfo[] afterCardInfos)
        {
            //先頭削除
            Destroy(_cardRectTransforms[0].gameObject);
            
            //一個詰める
            for (int i = 1; i < _displayCardCount; i++)
            {
                _cardRectTransforms[i - 1] = _cardRectTransforms[i];
            }
            
            //新しいカードを作成
            Image cardImage = Instantiate(_cardPrefab, transform);
            cardImage.sprite = afterCardInfos[(_displayCardCount - 1) % afterCardInfos.Length].CardImage;
            _cardRectTransforms[^1] = cardImage.GetComponent<RectTransform>();
            _cardRectTransforms[^1].anchoredPosition = _cardRectTransforms[^2].anchoredPosition + Vector2.up * 280;
            
            _movingTweener.ForEach(t => t?.Kill());
            _movingTweener.Clear();
            //アニメーションを再生
            for (int i = 0; i < _displayCardCount; i++)
            {
                var tween = _cardRectTransforms[i].DOAnchorPosY(_bottomOrigin.anchoredPosition.y + i * 280, 1);
                _movingTweener.Add(tween);
            }
        }
    }
}