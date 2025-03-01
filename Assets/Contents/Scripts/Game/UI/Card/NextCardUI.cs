using System;
using Game.Player;
using UnityEngine;

namespace Game.UI.Card
{
    public class NextCardUI : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;
        SpriteRenderer _spriteRenderer;
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            UpdateUI((float)_playerInfo.Energy / _playerInfo.NowDeck[0].Cost);
        }

        public void UpdateUI(float rate)
        {
            _spriteRenderer.sprite = _playerInfo.NowDeck[0].Info.CardImage;
            rate = Mathf.Clamp01(rate);
            _spriteRenderer.color = new Color(rate, rate, rate, 1);
        }
    }
}