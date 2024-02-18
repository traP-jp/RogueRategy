using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuffStack))]
[RequireComponent(typeof(BulletStatus))]
public class BulletManager : MonoBehaviour
{
    public BuffStack buffStack;
    public BulletMovementSimple bulletMovement;
    public BulletStatus bulletStatus;
}
