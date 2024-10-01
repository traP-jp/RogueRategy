using System.Collections.Generic;
using UnityEngine;

namespace CardEffect
{
    public class CardUseProcessor : SingletonMonoBehaviour<CardUseProcessor>
    {
        Dictionary<string, ICardEffectProcessor> _nameToProcessors;
        new void Awake()
        {
            _nameToProcessors = new Dictionary<string, ICardEffectProcessor>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform childTransform = transform.GetChild(i);
                _nameToProcessors.Add(childTransform.name, childTransform.GetComponent<ICardEffectProcessor>());
            }
        }
        public void UseCard(ICardEffect[] cardEffects, StatusBase status, Vector2 usePos)
        {
            for (int i = 0; i < cardEffects.Length; i++)
            {
                UseEffect(cardEffects[i], status, usePos);
            }
        }

        void UseEffect(ICardEffect cardEffect, StatusBase status, Vector2 usePos)
        {
            string className = cardEffect.GetType().Name;
            _nameToProcessors[className].Process(status,usePos);
        }
    }
}