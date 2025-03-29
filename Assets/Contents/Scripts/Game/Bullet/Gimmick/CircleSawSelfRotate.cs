using System;
using UnityEngine;

namespace Game.Bullet.Gimmick
{
    public class CircleSawSelfRotate : MonoBehaviour
    {
        [SerializeField] float _angleVelocity;
        float _nowZ = 0;
        
        void Update()
        {
            _nowZ += _angleVelocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _nowZ));
        }
    }
}