using System;
using System.Collections;
using Game.Player;
using UnityEngine;

namespace Game.Parameter.Energy
{
    public class EnergyAutoCharger : MonoBehaviour
    {
        [SerializeField] PlayerInfo _playerInfo;
        void Start()
        {
            StartCoroutine(AutoCharge());
        }

        IEnumerator AutoCharge()
        {
            while (true)
            {
                yield return new WaitForSeconds(_playerInfo.EnergyChargeInterval);
                _playerInfo.Energy += 1;
            }
        }
    }
}