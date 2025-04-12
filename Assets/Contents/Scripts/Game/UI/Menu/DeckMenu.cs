using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Card;
using DG.Tweening;
using UniRx;
using UnityEngine.InputSystem;
using Game.UI.Card;
using TMPro;

namespace Game.UI
{
    public class DeckMenu : MonoBehaviour
    {
        [SerializeField] List<CardInfo> cardInfoList;
        [SerializeField] DeckCardSelects deckCardSelects;
        [SerializeField] private CardAppearanceInitializer cardAppearanceInitializer;

        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI explain;

        private GameInputs _gameInputs;
        private int currentSelectIndex = 0;
        private bool isHolding = false;

        public void OpenDeckMenu(GameInputs gameinputs)
        {
            _gameInputs = gameinputs;
            gameObject.SetActive(true);
            deckCardSelects.SetCardInfoList(cardInfoList);
            _gameInputs.PrepareScene.Decide.performed += OnDecideButton;
            _gameInputs.PrepareScene.Up.performed += OnUpButton;
            _gameInputs.PrepareScene.Down.performed += OnDownButton;
            ShowSelectCard();
        }

        public void CloseDeckMenu()
        {
            gameObject.SetActive(false);
            _gameInputs.PrepareScene.Decide.performed -= OnDecideButton;
            _gameInputs.PrepareScene.Up.performed -= OnUpButton;
            _gameInputs.PrepareScene.Down.performed -= OnDownButton;
        }

        // 決定ボタンを押したときの処理
        public void OnDecideButton(InputAction.CallbackContext context)
        {
            isHolding = !isHolding;
            deckCardSelects.SetSelectIndex(isHolding);
            Debug.Log("Decide");
        }

        // 上ボタンを押した時の処理
        public void OnUpButton(InputAction.CallbackContext context)
        {
            if (currentSelectIndex > 0)
            {
                currentSelectIndex--;
                deckCardSelects.OnUpButton();
                ShowSelectCard();
            }
        }

        // 下ボタンを押した時の処理
        public void OnDownButton(InputAction.CallbackContext context)
        {
            if (currentSelectIndex < cardInfoList.Count - 1)
            {
                currentSelectIndex++;
                deckCardSelects.OnDownButton();
                ShowSelectCard();
            }
        }

        private void ShowSelectCard()
        {
            CardInfo cardInfo = cardInfoList[currentSelectIndex];
            cardAppearanceInitializer.Initialize(cardInfo.CardImage,cardInfo.Cost);
            name.text = cardInfo.name;
            explain.text = cardInfo.CardExplanation;
        }
    }
}
