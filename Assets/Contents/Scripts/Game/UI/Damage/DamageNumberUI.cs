using System;
using TMPro;
using UnityEngine;

namespace Game.UI.Damage
{
    public class DamageNumberUI : SingletonMonoBehaviour<DamageNumberUI>
    {
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] Transform _damageParent;
        Camera _camera;

        void Start()
        {
            _camera = Camera.main;
        }

        public void Generate(int damageAmount, Vector2 startPosition)
        {
            var damageText = Instantiate(_text, _damageParent);
            damageText.transform.position = startPosition;
            damageText.gameObject.SetActive(true);
            damageText.text = damageAmount.ToString();
        }
    }
}