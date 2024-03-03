using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 3.0f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector3(
            transform.position.x + moveX,
            transform.position.y + moveZ, // Add vertical movement
            transform.position.z + moveZ
        );
    }
}