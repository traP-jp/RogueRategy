using System.Collections.Generic;
using Game.Card;
using Game.UI.Energy;
using Game.Unit;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] int _energy;
        [SerializeField] float _energyChargeInterval;
        [SerializeField] int _health;
        [SerializeField] UnitStatus _unitStatus;
        [SerializeField] List<CardInfo> _deck;

        [SerializeField] EnergyUI _energyUI; 
        public int Energy
        {
            get => _energy;
            set
            {
                int oldEnergy = _energy;
                _energy = Mathf.Clamp(value,0,9);
                _energyUI.UpdateUI(oldEnergy, _energy);
            }
        }

        public float EnergyChargeInterval
        {
            get => _energyChargeInterval;
            set => _energyChargeInterval = value;
        }

        public int Health
        {
            get => _health;
            set => _health = value;
        }

        public UnitStatus UnitStatus => _unitStatus;

        public List<CardInfo> Deck => _deck;
    }
}