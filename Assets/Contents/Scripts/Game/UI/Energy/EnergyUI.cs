using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Energy
{
    public class EnergyUI : MonoBehaviour
    {
        [SerializeField] Sprite[] _energySprites;
        Image _energySprite;
        
        void Awake()
        {
            _energySprite = GetComponent<Image>();
        }

        public void UpdateUI(int oldEnergy, int newEnergy)
        {
            _energySprite.sprite = _energySprites[newEnergy];
        }
    }
}