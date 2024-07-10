using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    IDamagable damagable;
    private void Awake()
    {
        damagable = GetComponent<IDamagable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵の情報を管理するところにIDamagableをつける
        BulletStatus collidedBulletStatus = collision.GetComponent<BulletStatus>();
        damagable.AddDamage(Mathf.RoundToInt(collidedBulletStatus.GetDamage()));
        if (collidedBulletStatus.destroyOnCollision)
        {
            Destroy(collision.gameObject);   
        }
    }
}

public interface IDamagable
{
    void AddDamage(int strength);
    void ConveyBuff(BuffStack bulletsBuffStack);
}
