using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementSimple : MonoBehaviour,IBulletMovement
{
    float VX = 0;
    float VY = 0;

    public void Initialize(float speed,bool isPlayerSide)
    {
        Vector2 velocityVector;
        if (isPlayerSide)
        {
            velocityVector = Info.Instance.enemyTransform.position - transform.position;
        }
        else
        {
            velocityVector = Info.Instance.playerManager.transform.position - transform.position;
        }   
        velocityVector.Normalize();
        velocityVector *= speed;
        VX = velocityVector.x;
        VY = velocityVector.y;
    }
    private void Update()
    {
        transform.position = Vector2.right * VX * Time.deltaTime + (Vector2)transform.position;
        transform.position = Vector2.up * VY * Time.deltaTime + (Vector2)transform.position;
    }
    


}
