using System;
using System.Collections.Generic;
using System.Linq;
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
            _playerInfo.NowDeck = _playerInfo.Deck
                .Select(info => new NowCard() { Cost = info.Cost, Info = info })
                .ToList();
            _cardUI.InitializeCardDeck(_playerInfo.Deck);
        }

        void Update()
        {
            if (_playerInfo.NowDeck[0].Cost <= _playerInfo.Energy)
            {
                _playerInfo.Energy -= _playerInfo.Deck[0].Cost;
                UseTopCard();
                DeleteTopCard();
            }
        }

        void DeleteTopCard()
        {
            var topCard = _playerInfo.NowDeck[0];
            for (int i = 1; i < _playerInfo.Deck.Length; i++)
            {
                _playerInfo.NowDeck[i - 1] = _playerInfo.NowDeck[i];
            }
            _playerInfo.NowDeck[^1] = new NowCard(){Cost = topCard.Info.Cost, Info = topCard.Info};
            _cardUI.OnUseBottomCard(_playerInfo.NowDeck.Select(c => c.Info).ToArray());
        }

        void UseTopCard()
        {
            var topCard = _playerInfo.NowDeck[0].Info;
            CardEffectUse.Instance.UseEffect(topCard.CardEffectInfo, _playerInfo.UnitStatus, _playerInfo.transform.position);
        }
    }
}