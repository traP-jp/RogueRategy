using System;
using UnityEngine;

namespace Game.Unit
{
    public class UnitTargetSubscriber : MonoBehaviour
    {
        [SerializeField] UnitStatus _unitStatus;

        void Start()
        {
            UnitTargetDecider.Instance.Subscribe(transform, _unitStatus.IsPlayerSide);
        }

        void OnDestroy()
        {
            UnitTargetDecider.Instance.UnSubscribe(transform, _unitStatus.IsPlayerSide);
        }
    }
}