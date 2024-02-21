using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementSimple : MonoBehaviour
{
    [SerializeField]float velocityX = 1;

    [SerializeField] float intervalTime = 0.3f;

    [SerializeField] BulletManager bullet;

    [SerializeField] UnitManager unitManager;

    private void Start()
    {
        StartCoroutine(AttackWithIntervalTime(intervalTime));
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = transform.position;
        moveVector += new Vector2(velocityX * Time.deltaTime, 0);
        transform.position = moveVector;
    }

    IEnumerator AttackWithIntervalTime(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            BulletManager bulletManager = Instantiate(bullet, transform.position, Quaternion.identity, this.transform);
            bulletManager.bulletStatus.SettingAttack(unitManager.unitStatus.resultAttack);
            bulletManager.bulletMovement.Initialize(5);
            unitManager.ConveyBuffToBullet(bulletManager);
        }
    }
}
