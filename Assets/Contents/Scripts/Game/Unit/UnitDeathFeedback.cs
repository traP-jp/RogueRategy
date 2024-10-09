using System;
using UnityEngine;
using UniRx;

namespace Game.Unit
{
    public class UnitDeathFeedback : MonoBehaviour
    {
        [SerializeField] UnitStatus _status;
        [SerializeField] GameObject _destroyObject;

        void Awake()
        {
            _status.HealthPoint
                .Where(value => value <= 0)
                .Subscribe(_ => Destroy(_destroyObject));
        }
    }
}