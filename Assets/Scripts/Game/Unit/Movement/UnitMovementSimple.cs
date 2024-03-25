using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementSimple : MonoBehaviour
{
    [SerializeField] float intervalTime = 0.3f;

    [SerializeField] CardInfo cardEffect;

    [SerializeField] UnitManager unitManager;

    private void Start()
    {
        StartCoroutine(AttackWithIntervalTime(intervalTime));
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = transform.position;
        moveVector += new Vector2(unitManager.unitStatus.resultSpeed * Time.deltaTime, 0);
        transform.position = moveVector;
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
