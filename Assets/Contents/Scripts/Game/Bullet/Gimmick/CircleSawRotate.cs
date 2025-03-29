using System;
using UnityEngine;

namespace Game.Bullet.Gimmick
{
    public class CircleSawRotate : MonoBehaviour
    {
        [SerializeField] float _radius;
        [SerializeField] float _rotationVelocity;
        [SerializeField] int _sawCount;
        [SerializeField] Transform _sawPrefab;
        [SerializeField] float _duration;

        Transform[] _sawList;
        float _nowZ;
        
        void Start()
        {
            _sawList = new Transform[_sawCount];
            float deltaRadian = 2 * Mathf.PI / _sawCount;
            for (int i = 0; i < _sawCount; i++)
            {
                Vector3 nowPosition = transform.position;
                nowPosition.x += _radius * Mathf.Cos(deltaRadian * i);
                nowPosition.y += _radius * Mathf.Sin(deltaRadian * i);
                _sawList[i] = Instantiate(_sawPrefab, nowPosition, Quaternion.identity, transform);
            }
        }

        void Update()
        {
            _nowZ += _rotationVelocity * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,_nowZ));
            _duration -= Time.deltaTime;
            if (_duration < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}