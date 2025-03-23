using Game.Card.Area;
using Game.Card.CardEffectSetting;
using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class HealthAutoRecoveryAreaProcessor : MonoBehaviour
    {
        [SerializeField] HealthRecoverArea _healthRecoverAreaPrefab;
        public void Process(UnitStatus userStatus, HealthAutoRecoverArea setting)
        {
            var prefab = Instantiate(_healthRecoverAreaPrefab, userStatus.transform.position, Quaternion.identity,
                userStatus.transform);
            prefab.RecoverAmount = setting.RecoveryAmount;
            prefab.RecoverInterval = setting.RecoveryInterval;
            prefab.IsPlayerSideOnly = userStatus.IsPlayerSide;
        }
    }
}