using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Card
{
    public class CardAppearanceInitializer : MonoBehaviour
    {
        [SerializeField] Image _image;
        [SerializeField] TextMeshProUGUI _costText;

        public void Initialize(Sprite sprite, int cost)
        {
            _image.sprite = sprite;
            _costText.text = cost.ToString();
        }

        public void UpdateCost(int newCost)
        {
            _costText.text = newCost.ToString();
        }
    }
}