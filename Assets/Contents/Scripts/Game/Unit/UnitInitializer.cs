using System;
using Game.Unit.Movement;
using UnityEngine;

namespace Game.Unit
{
    public class UnitInitializer : MonoBehaviour
    {
        [SerializeField] UnitStatus _status;
        IUnitMovement _unitMovement;


        void Awake()
        {
            _unitMovement = GetComponent<IUnitMovement>();
        }

        public void Initialize(int userAttack, bool isPlayerSide)
        {
            _status.IsPlayerSide = isPlayerSide;
            _status.AttackNormal = userAttack + _status.AttackNow;
            _unitMovement.Initialize(_status.IsPlayerSide, _status.Speed);
        }
    }
}