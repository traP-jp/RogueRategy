using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementExplosion : MonoBehaviour,IBulletMovement
{
    [SerializeField] SpriteAnimation _spriteAnimation;
    public void Initialize(float speed,bool isPlayerSide)
    {
        _spriteAnimation.Initialize(FinishAndDestroy);
        GetComponent<BulletStatus>().destroyOnCollision = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    public void FinishAndDestroy(int _)
    {
        Destroy(this.gameObject);
    }
}
