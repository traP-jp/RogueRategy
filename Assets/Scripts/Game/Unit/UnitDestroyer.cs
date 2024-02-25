using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDestroyer : MonoBehaviour
{
    [SerializeField] private bool destroyByAlly;
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!(collider.gameObject.CompareTag("ally") && !destroyByAlly))
        {
            Destroy(gameObject);
        }
    }
}
