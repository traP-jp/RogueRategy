using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitDestroyer : MonoBehaviour
{
    [SerializeField] private bool destroyByAlly;
    UnitStatus status;

    private void Start()
    {
        status = GetComponent<UnitStatus>();
    }

    private void Update()
    {
        DestroyCheck();
        DestroyOnDeath();
    }

    private void DestroyCheck()
    {
        if (Math.Abs(transform.position.x) <= 10f && Math.Abs(transform.position.y) <= 6f) return;
        Destroy(gameObject);
        
    }

    void DestroyOnDeath()
    {
        //HPが0以下になったら消す
        if(status?.HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
