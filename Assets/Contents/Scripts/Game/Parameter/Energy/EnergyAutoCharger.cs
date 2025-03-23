using Game.Player;
using UnityEngine;

namespace Game.Parameter.Energy
{
    public class EnergyAutoCharger : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;

        void Update()
        {
            _playerInfo.Energy += Time.deltaTime / _playerInfo.EnergyChargeInterval;
        }
    }
}