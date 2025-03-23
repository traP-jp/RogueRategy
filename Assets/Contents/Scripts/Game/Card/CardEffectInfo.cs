using Game.Card.CardEffectSetting;
using UnityEngine;

namespace Game.Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/CardEffect", fileName = "CardEffect")]
    public class CardEffectInfo : ScriptableObject
    {
        [SerializeReference, SubclassSelector] public ICardEffectSetting[] CardEffects;
    }
}