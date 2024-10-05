using System;
using Game.Player;
using Game.UI.Card;
using UnityEngine;

namespace Game.Card
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;
        [SerializeField] CardUI _cardUI;
        
        void Start()
        {
            _cardUI.InitializeCardDeck(_playerInfo.Deck.ToArray());
        }

        void Update()
        {
            if (_playerInfo.Deck[0].Cost <= _playerInfo.Energy)
            {
                _playerInfo.Energy -= _playerInfo.Deck[0].Cost;
                UseTopCard();
                DeleteTopCard();
            }
        }

        void DeleteTopCard()
        {
            var topCard = _playerInfo.Deck[0];
            for (int i = 1; i < _playerInfo.Deck.Count; i++)
            {
                _playerInfo.Deck[i - 1] = _playerInfo.Deck[i];
            }
            _playerInfo.Deck[^1] = topCard;
            _cardUI.OnUseBottomCard(_playerInfo.Deck.ToArray());
        }

        void UseTopCard()
        {
            var topCard = _playerInfo.Deck[0];
            CardEffectUse.Instance.UseEffect(topCard.CardEffectInfo, _playerInfo.UnitStatus, _playerInfo.transform.position);
        }
    }
}