using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Card;

namespace Game.Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerInfoData", fileName = "PlayerInfoData")]
    public class PlayerInfoData : ScriptableObject
    {
        [SerializeField] float _energyChargeInterval;
        [SerializeField] CardInfo[] _deck;
        [SerializeField] float _speed;
        [SerializeField] int _attackDefault;
        [SerializeField] int _attackNormal;
        [SerializeField] float _invictionInterval;
        [SerializeField] float _coinCollectEfficiency;

        public float EnergyChargeInterval
        {
            get => _energyChargeInterval;
            set => _energyChargeInterval = value;
        }

        public CardInfo[] Deck => _deck;
        public void AddCardInfo(CardInfo cardInfo)
        {
            List<CardInfo> deck = new List<CardInfo>(_deck);
            deck.Add(cardInfo);
            _deck = deck.ToArray();
        }
        public void RemoveCardInfo(CardInfo cardInfo)
        {
            List<CardInfo> deck = new List<CardInfo>(_deck);
            deck.Remove(cardInfo);
            _deck = deck.ToArray();
        }
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        public int AttackDefault
        {
            get => _attackDefault;
            set => _attackDefault = value;
        }
        public int AttackNormal
        {
            get => _attackNormal;
            set => _attackNormal = value;
        }
        public float InvictionInterval
        {
            get => _invictionInterval;
            set => _invictionInterval = value;
        }
        public float CoinCollectEfficiency
        {
            get => _coinCollectEfficiency;
            set => _coinCollectEfficiency = value;
        }
    }
}