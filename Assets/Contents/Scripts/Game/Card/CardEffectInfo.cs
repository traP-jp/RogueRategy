using Game.Bullet;
using Game.Card.CardEffectSetting;
using Game.Unit;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Game.Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/CardEffect", fileName = "CardEffect")]
    public class CardEffectInfo : ScriptableObject
    {
        [SerializeReference, SubclassSelector] public ICardEffectSetting[] CardEffects;
    }
}