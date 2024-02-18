using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementSimple : MonoBehaviour
{
    float VX, VY;
    public void SetupVelocity(float velocityX,float velocityY)
    {
        VX = velocityX;
        VY = velocityY;
    }
    private void Update()
    {
        transform.position = Vector2.right * VX * Time.deltaTime + (Vector2)transform.position;
        transform.position = Vector2.up * VY * Time.deltaTime + (Vector2)transform.position;
    }
}
