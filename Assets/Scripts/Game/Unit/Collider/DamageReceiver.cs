using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵の情報を管理するところにIDamagableをつける
        GetComponent<IDamagable>().AddDamage(10);
        Destroy(collision.gameObject);
    }
}

public interface IDamagable
{
    void AddDamage(int strength);
}
