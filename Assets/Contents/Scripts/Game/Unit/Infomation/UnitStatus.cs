using System;
using UniRx;
using UnityEngine;

namespace Game.Unit
{
    public class UnitStatus : MonoBehaviour
    {
        public IntReactiveProperty HealthPoint = new IntReactiveProperty();
        public IntReactiveProperty MaxHealthPoint = new IntReactiveProperty();
        public FloatReactiveProperty Speed = new FloatReactiveProperty();

        void Awake()
        {
            HealthPoint
                .Where(hp => hp > MaxHealthPoint.Value)
                .Subscribe(_ => HealthPoint.Value = MaxHealthPoint.Value);
        }
    }
}