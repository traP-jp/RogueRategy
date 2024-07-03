using System;
using UnityEngine;

public class BulletMovementLinear : MonoBehaviour, IBulletMovement
{
    Vector3 velocity;
    public void Initialize(float speed, bool isPlayerSide)
    {
        float theta = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        velocity = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0) * speed;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
