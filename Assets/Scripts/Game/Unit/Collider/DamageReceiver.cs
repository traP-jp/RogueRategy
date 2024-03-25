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
        damagable.AddDamage(Mathf.RoundToInt(collision.GetComponent<BulletStatus>().GetDamage()));
        Destroy(collision.gameObject);
    }
}

public interface IDamagable
{
    void AddDamage(int strength);
    void ConveyBuff(BuffStack bulletsBuffStack);
}
