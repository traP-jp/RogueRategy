using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class GenerateUnitProcessor : MonoBehaviour
    {
        public void Process(UnitInitializer unitInitializer, UnitStatus userStatus, Vector2 pos)
        {
            var prefab = Instantiate(unitInitializer, pos, Quaternion.identity, transform);
            prefab.Initialize(userStatus.AttackNow, userStatus.IsPlayerSide);
        }
    }
}