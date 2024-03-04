using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour,IBulletMovement
{
    [SerializeField] private Transform chased;
    float VX = 0;
    float VY = 0;
    private float _speed;
    private Rigidbody2D _rb;

    public void Initialize(float speed)
    {
        _speed = speed;
        Vector2 velocityVector = Info.Instance.enemyTransform.position - transform.position;
        velocityVector.Normalize();
        velocityVector *= _speed;
        _rb.velocity = velocityVector;
    }

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Updateでbulletに力を加える
        _rb.velocity.Normalize();
        _rb.velocity *= _speed;
    }
    


}