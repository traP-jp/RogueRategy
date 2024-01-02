using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementSimple : MonoBehaviour
{
    [SerializeField]float velocityX = 1;

    [SerializeField] float intervalTime = 0.3f;

    [SerializeField] GameObject bullet;

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
            GameObject tmp = Instantiate(bullet, transform.position, Quaternion.identity, this.transform);
            Vector2 velocityVector = Info.Instance.enemyTransform.position - transform.position;
            velocityVector.Normalize();
            velocityVector *= 5;
            tmp.GetComponent<BulletMovementSimple>().SetupVelocity(velocityVector.x, velocityVector.y);
        }
    }
}
