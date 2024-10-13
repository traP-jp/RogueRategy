using System;
using Game.Unit;
using UnityEngine;

namespace Game.Player
{
    public class PlayerStatusInitializer : MonoBehaviour
    {
        [SerializeField] UnitStatus _playerStatus;
        void Start()
        {
            _playerStatus.AttackNormal = _playerStatus.AttackDefault;
        }
    }
}