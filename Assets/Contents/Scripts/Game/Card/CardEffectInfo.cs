using Game.Bullet;
using Game.Unit;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Game.Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/CardEffect", fileName = "CardEffect")]
    public class CardEffectInfo : ScriptableObject
    {
        [SerializeField] CardEffect[] _cardEffects;
        public ReadOnlyArray<CardEffect> CardEffects => _cardEffects;
        
        [System.Serializable]
        public class CardEffect
        {
            public enum EffectKindEnum
            {
                GenerateBullet,
                GenerateUnit,
                HpRecover,
                EnergyRecover
            }

            [SerializeField] EffectKindEnum _effectKind;
            [SerializeField] BulletInitializer _bulletPrefab;
            [SerializeField] UnitInitializer _unitPrefab;
            [SerializeField] int _hpRecoverAmount;
            [SerializeField] int _energyRecoverAmount;
            
            public EffectKindEnum EffectKind => _effectKind;
            public BulletInitializer BulletPrefab => _bulletPrefab;
            public UnitInitializer UnitPrefab => _unitPrefab;
            public int HpRecoverAmount => _hpRecoverAmount;
            public int EnergyRecoverAmount => _energyRecoverAmount;
        }
    }
}