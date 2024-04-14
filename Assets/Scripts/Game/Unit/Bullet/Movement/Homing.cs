using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour,IBulletMovement
{
    //将来的には"ホーミング対象を定める(chasedのtransformに上手く追跡対象を入れたいがプレハブ故難しそう?)",
    //"ユニット側の設定でホーミングの強さを定める"ことができるような設計にしたい
    
    private Transform chased;
    [SerializeField] private float homingforce;
    private float _speed;
    private Rigidbody2D _rb;
    private Vector2 _positiondiff;

    public void Initialize(float speed,bool isPlayerSide)
    {
        _speed = speed;
        _positiondiff = chased.position - gameObject.transform.position;
        _positiondiff.Normalize();
        _positiondiff *= _speed;
        _rb.velocity = _positiondiff;
        Debug.Log(_rb.velocity);
    }

    private void Awake()
    {
        chased = Info.Instance.enemyTransform;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Updateでbulletに力を加える
        _positiondiff = chased.position - gameObject.transform.position;
        _rb.AddForce(_positiondiff.normalized*homingforce);
        
        _rb.velocity=_rb.velocity.normalized*_speed;
        Debug.Log(_rb.velocity);
    }
    


}