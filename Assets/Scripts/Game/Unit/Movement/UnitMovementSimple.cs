using System.Collections;
using System.Collections.Generic;
using CardEffect;
using UnityEngine;

public class UnitMovementSimple : MonoBehaviour
{
    [SerializeField] float intervalTime = 0.3f;

    [SerializeField] CardInfo cardEffect;

    [SerializeField] UnitManager unitManager;

    private void Start()
    {
        StartCoroutine(AttackWithIntervalTime(intervalTime));
        if (unitManager.isPlayerSide)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = transform.position;
        if (unitManager.isPlayerSide)
        {
            moveVector += new Vector2(unitManager.unitStatus.resultSpeed * Time.deltaTime, 0);
        }
        else
        {
            moveVector -= new Vector2(unitManager.unitStatus.resultSpeed * Time.deltaTime, 0); ;
        }
        transform.position = moveVector;
    }

    IEnumerator AttackWithIntervalTime(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            CardUseProcessor.Instance.UseCard(cardEffect.cardEffectInfo, unitManager.unitStatus, transform.position);
        }
    }
    
}
