using System;
using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.UI.Card
{
    public class NextCardUI : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;
        [SerializeField] TMP_Text _text;
        SpriteRenderer _spriteRenderer;
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            UpdateUI((float)_playerInfo.Energy / _playerInfo.NowDeck[0].Cost);
            UpdateText(_playerInfo.NowDeck[0].Cost - _playerInfo.Energy);
        }

        public void UpdateUI(float rate)
        {
            _spriteRenderer.sprite = _playerInfo.NowDeck[0].Info.CardImage;
            rate = Mathf.Clamp01(rate);
            _spriteRenderer.color = new Color(rate, rate, rate, 1);
        }

        void UpdateText(float delta)
        {
            int displayNum = Mathf.CeilToInt(delta);
            _text.gameObject.SetActive(displayNum > 0);
            _text.text = Mathf.CeilToInt(delta).ToString();
        }
    }
}