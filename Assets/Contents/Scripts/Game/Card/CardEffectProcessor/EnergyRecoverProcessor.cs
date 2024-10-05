using Game.Player;
using Game.Unit;
using UnityEngine;

namespace Game.Card.CardEffectProcessor
{
    public class EnergyRecoverProcessor : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;
        public void Process(int recoverAmount)
        {
            _playerInfo.Energy += recoverAmount;
        }
    }
}