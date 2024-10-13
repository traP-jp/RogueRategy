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
                    _cardCostDownProcessor.Process(ccd.CardCount, ccd.CostRatio, ccd.DownAmount);
                    break;
            }
        }
    }
}