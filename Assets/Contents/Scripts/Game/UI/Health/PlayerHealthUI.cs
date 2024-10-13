using System;
using Game.Unit;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace Game.UI.Health
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] UnitStatus _playerStatus;
        [SerializeField] Sprite[] _sprites;

        Image _healthUiImage;

        void Awake()
        {
            _healthUiImage = GetComponent<Image>();
        }

        void Start()
        {
            _playerStatus.HealthPoint.Subscribe(UpdateUI);
            UpdateUI(_playerStatus.HealthPoint.Value);
        }

        void UpdateUI(int health)
        {
            if (health > 1500) health = 1500;
            _healthUiImage.sprite = _sprites[(health + 99)/ 100];
        }
    }
}