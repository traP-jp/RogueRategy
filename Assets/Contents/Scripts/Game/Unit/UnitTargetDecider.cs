using System.Collections.Generic;
using UnityEngine;

namespace Game.Unit
{
    public class UnitTargetDecider : SingletonMonoBehaviour<UnitTargetDecider>
    {
        List<Transform> _playerSideTransforms = new List<Transform>();
        List<Transform> _enemySideTransforms = new List<Transform>();

        public void Subscribe(Transform unitTransform, bool isPlayerSide)
        {
            if (isPlayerSide) _playerSideTransforms.Add(unitTransform);
            else _enemySideTransforms.Add(unitTransform);
        }

        public void UnSubscribe(Transform unitTransform, bool isPlayerSide)
        {
            if (isPlayerSide) _playerSideTransforms.Remove(unitTransform);
            else _enemySideTransforms.Remove(unitTransform);
        }

        public Transform GetNearestTarget(Vector2 nowPosition, bool isTargetPlayerSide)
        {
            List<Transform> useList = isTargetPlayerSide ? _playerSideTransforms : _enemySideTransforms;
            Transform nearestTransform = null;
            float distanceSquared = float.MaxValue;
            foreach (var t in useList)
            {
                float sqrMag = ((Vector2)t.position - nowPosition).sqrMagnitude;
                if (sqrMag < distanceSquared)
                {
                    nearestTransform = t;
                    distanceSquared = sqrMag;
                }
            }

            return nearestTransform;
        }
    }
}