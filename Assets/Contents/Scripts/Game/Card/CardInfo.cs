using System;
using UnityEngine;

namespace Game.Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/CardInfo", fileName = "CardInfo")]
    public class CardInfo : ScriptableObject
    {
        [SerializeField] Sprite _cardImage;
        [SerializeField] int _cost;
        [SerializeField] string _cardName;
        [SerializeField] string _cardExplanation;
        [SerializeField] CardEffectInfo _cardEffectInfo;

        public Sprite CardImage => _cardImage;
        public int Cost => _cost;
        public string CardName => _cardName;
        public string CardExplanation => _cardExplanation;
        public CardEffectInfo CardEffectInfo => _cardEffectInfo;

    }
}