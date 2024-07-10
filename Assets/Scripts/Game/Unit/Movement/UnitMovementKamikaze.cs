using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UnitMovementKamikaze : MonoBehaviour
{
    [SerializeField] CardInfo onColliderEffect;
    [SerializeField] float velocity;

    UnitManager unitManager;
    

    private void Start()
    {
        unitManager = GetComponent<UnitManager>();
        if (unitManager.isPlayerSide)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void Update()
    {
        transform.position += new Vector3(unitManager.unitStatus.resultSpeed * velocity * Time.deltaTime, 0, 0);
    }
}
