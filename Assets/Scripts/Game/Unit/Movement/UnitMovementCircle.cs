using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnitMovementCircle : MonoBehaviour
{
    [SerializeField] float intervalTime = 0.3f;
    [SerializeField] float moveDeltaX = 2;
    [SerializeField] CardInfo cardEffect;

    UnitManager unitManager;
    

    private void Start()
    {
        unitManager = GetComponent<UnitManager>();
        StartCoroutine(AttackWithIntervalTime(intervalTime));
        if (unitManager.isPlayerSide)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        transform.DOMoveX(transform.position.x + moveDeltaX, 4 / unitManager.unitStatus.resultSpeed)
            .OnComplete(() => StartCoroutine(AttackWithIntervalTime(intervalTime)));
    }

    IEnumerator AttackWithIntervalTime(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            cardEffect.cardEffectInfo.Process(unitManager.unitStatus,transform.position);
        }
    }

}
