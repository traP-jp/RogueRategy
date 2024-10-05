using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class HealthRecoverProcessor : MonoBehaviour
    {
        public void Process(UnitStatus userStatus, Vector2 userPos,int recoverAmount)
        {
            userStatus.HealthPoint.Value += recoverAmount;
        }
    }
}