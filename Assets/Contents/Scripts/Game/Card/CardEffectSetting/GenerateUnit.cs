using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectSetting
{
    [System.Serializable]
    public class GenerateUnit : ICardEffectSetting
    {
        public UnitInitializer UnitPrefab;
    }
}