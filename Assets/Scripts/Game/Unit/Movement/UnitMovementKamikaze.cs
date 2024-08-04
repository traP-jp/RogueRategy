using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UnitMovementKamikaze : MonoBehaviour
{
    [SerializeField] CardInfo onColliderEffect;
    [SerializeField] float velocity;
    [SerializeField] Vector2 offset;
    [SerializeField] GameObject childCollider;

    UnitManager unitManager;
    

    private void Start()
    {
        unitManager = GetComponent<UnitManager>();
        if (unitManager.isPlayerSide)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            childCollider.layer = 7;
        }
        else
        {
            velocity *= -1;
            childCollider.layer = 9;
        }
    }

    void Update()
    {
        transform.position += new Vector3(unitManager.unitStatus.resultSpeed * velocity * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 && unitManager.isPlayerSide)
        {
            onColliderEffect?.cardEffectInfo.Process(unitManager.unitStatus, transform.position + (Vector3)offset);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 10 && !unitManager.isPlayerSide)
        {
            onColliderEffect?.cardEffectInfo.Process(unitManager.unitStatus, transform.position + (Vector3)offset);
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 && unitManager.isPlayerSide)
        {
            onColliderEffect?.cardEffectInfo.Process(unitManager.unitStatus, transform.position + (Vector3)offset);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 10 && !unitManager.isPlayerSide)
        {
            onColliderEffect?.cardEffectInfo.Process(unitManager.unitStatus, transform.position + (Vector3)offset);
            Destroy(gameObject);
        }
    }
}
