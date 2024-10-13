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
        [SerializeField] CardAppearanceInitializer _cardPrefab;
        RectTransform[] _cardRectTransforms;
        readonly List<Tweener> _movingTweener = new List<Tweener>();

        public void InitializeCardDeck(NowCard[] cardInfos)
        {
            _cardRectTransforms = new RectTransform[_displayCardCount];
            for (int i = 0; i < _displayCardCount; i++)
            {
                CardAppearanceInitializer cardAppearance = Instantiate(_cardPrefab, transform);
                NowCard displayCard = cardInfos[i % cardInfos.Length];
                cardAppearance.Initialize(displayCard.Info.CardImage, displayCard.Cost);
                _cardRectTransforms[i] = cardAppearance.GetComponent<RectTransform>();
                _cardRectTransforms[i].anchoredPosition = _bottomOrigin.anchoredPosition + Vector2.up * i * 280;
            }
        }

        public void OnUseBottomCard(NowCard[] afterCardInfos)
        {
            //先頭削除
            Destroy(_cardRectTransforms[0].gameObject);
            
            //一個詰める
            for (int i = 1; i < _displayCardCount; i++)
            {
                _cardRectTransforms[i - 1] = _cardRectTransforms[i];
            }
            
            //新しいカードを作成
            var cardAppearance = Instantiate(_cardPrefab, transform);
            NowCard displayCard = afterCardInfos[(_displayCardCount - 1) % afterCardInfos.Length];
            cardAppearance.Initialize(displayCard.Info.CardImage, displayCard.Cost);
            _cardRectTransforms[^1] = cardAppearance.GetComponent<RectTransform>();
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