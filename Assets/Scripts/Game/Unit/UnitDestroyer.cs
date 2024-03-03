using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitDestroyer : MonoBehaviour
{
    [SerializeField] private bool destroyByAlly;

    private void Update()
    {
        DestroyCheck();
    }

    private void DestroyCheck()
    {
        if (Math.Abs(transform.position.x) <= 10f && Math.Abs(transform.position.y) <= 6f) return;
        Destroy(gameObject);
        
    }
}
