using System;
using TMPro;
using UnityEngine;

namespace Game.UI.Damage
{
    public class DamageNumberUI : SingletonMonoBehaviour<DamageNumberUI>
    {
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] Transform _damageParent;

        public void GenerateDamage(int damageAmount, Vector2 startPosition)
        {
            var damageText = Instantiate(_text, _damageParent);
            damageText.transform.position = startPosition;
            damageText.gameObject.SetActive(true);
            damageText.text = damageAmount.ToString();
        }

        public void GenerateHeal(int healAmount, Vector2 startPosition)
        {
            var damageText = Instantiate(_text, _damageParent);
            damageText.color = new Color(0, 1, 0.65f);
            damageText.transform.position = startPosition;
            damageText.gameObject.SetActive(true);
            damageText.text = healAmount.ToString();
        }
    }
}