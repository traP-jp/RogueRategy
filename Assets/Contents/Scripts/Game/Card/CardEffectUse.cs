using Game.Card.CardEffectProcessor;
using Game.Card.CardEffectSetting;
using Game.Unit;
using UnityEngine;

namespace Game.Card
{
    public class CardEffectUse : SingletonMonoBehaviour<CardEffectUse>
    {
        [SerializeField] GenerateBulletProcessor _generateBulletProcessor;
        [SerializeField] GenerateUnitProcessor _generateUnitProcessor;
        [SerializeField] HealthRecoverProcessor _healthRecoverProcessor;
        [SerializeField] EnergyRecoverProcessor _energyRecoverProcessor;
        [SerializeField] AddBuffProcessor _addBuffProcessor;
        [SerializeField] CardCostDownProcessor _cardCostDownProcessor;
        [SerializeField] RemoveAllDebuffProcessor _removeAllDebuffProcessor;
        [SerializeField] HealthAutoRecoveryAreaProcessor _healthAutoRecoveryAreaProcessor;
        [SerializeField] FlashDamageProcessor _flashDamageProcessor;

        public void UseEffect(CardEffectInfo cardEffectInfo, UnitStatus userStatus, Vector2 pos)
        {
            UseEffect(cardEffectInfo.CardEffects, userStatus, pos);
        }
        public void UseEffect(ICardEffectSetting[] cardEffectSettings, UnitStatus userStatus, Vector2 pos)
        {
            for(int i = 0; i < cardEffectSettings.Length; i++)
            {
                UseOneEffect(cardEffectSettings[i], userStatus, pos);
            }
        }

        void UseOneEffect(ICardEffectSetting cardEffectSetting, UnitStatus userStatus, Vector2 pos)
        {
            
            switch (cardEffectSetting.GetType().Name)
            {
                case "GenerateBullet":
                    GenerateBullet gb = (GenerateBullet)cardEffectSetting;
                    _generateBulletProcessor.Process(gb.BulletPrefab, userStatus, pos);
                    break;
                case "GenerateUnit":
                    GenerateUnit gu = (GenerateUnit)cardEffectSetting;
                    _generateUnitProcessor.Process(gu.UnitPrefab, userStatus, pos);
                    break;
                case "HealthRecover":
                    HealthRecover hr = (HealthRecover)cardEffectSetting;
                    _healthRecoverProcessor.Process(userStatus, pos,hr.RecoverAmount);
                    break;
                case "EnergyRecover":
                    EnergyRecover er = (EnergyRecover)cardEffectSetting;
                    _energyRecoverProcessor.Process(er.RecoverAmount);
                    break;
                case "AddBuff":
                    AddBuff ab = (AddBuff)cardEffectSetting;
                    _addBuffProcessor.Process(userStatus, ab.Buff);
                    break;
                case "CardCostDown":
                    CardCostDown ccd = (CardCostDown)cardEffectSetting;
                    _cardCostDownProcessor.Process(ccd.CardCount, ccd.CostRatio, ccd.DownAmount, ccd.MaxCost);
                    break;
                case "RemoveAllDebuff":
                    RemoveAllDebuff rad = (RemoveAllDebuff)cardEffectSetting;
                    _removeAllDebuffProcessor.Process(userStatus);
                    break;
                case "HealthAutoRecoverArea":
                    HealthAutoRecoverArea hara = (HealthAutoRecoverArea)cardEffectSetting;
                    _healthAutoRecoveryAreaProcessor.Process(userStatus, hara);
                    break;
                case "FlashDamage":
                    FlashDamage flashDamage = (FlashDamage)cardEffectSetting;
                    _flashDamageProcessor.Process(userStatus, flashDamage);
                    break;
            }
        }
    }
}