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
            _playerInfo.NowDeck = new List<NowCard>();
            while (_playerInfo.NowDeck.Count < 10)
            {
                foreach (var c in _playerInfo.Deck
                             .Select(info => new NowCard() { Cost = info.Cost, Info = info })
                             .ToList())
                {
                    _playerInfo.NowDeck.Add(c);
                }
            }
            _cardUI.InitializeCardDeck(_playerInfo.NowDeck.ToArray());
        }

        void Update()
        {
            if (_playerInfo.NowDeck[0].Cost <= _playerInfo.Energy)
            {
                _playerInfo.Energy -= _playerInfo.Deck[0].Cost;
                UseTopCard();
                DeleteTopCard();
                UpdateCardCostUI();
            }
        }

        void DeleteTopCard()
        {
            var topCard = _playerInfo.NowDeck[0];
            for (int i = 1; i < _playerInfo.NowDeck.Count; i++)
            {
                _playerInfo.NowDeck[i - 1] = _playerInfo.NowDeck[i];
            }
            _playerInfo.NowDeck[^1] = new NowCard(){Cost = topCard.Info.Cost, Info = topCard.Info};
            _cardUI.OnUseBottomCard(_playerInfo.NowDeck.ToArray());
        }

        void UseTopCard()
        {
            var topCard = _playerInfo.NowDeck[0].Info;
            CardEffectUse.Instance.UseEffect(topCard.CardEffectInfo, _playerInfo.UnitStatus, _playerInfo.transform.position);
        }

        void UpdateCardCostUI()
        {
            _cardUI.UpdateCost(_playerInfo.NowDeck.ToArray());
        }
    }
}