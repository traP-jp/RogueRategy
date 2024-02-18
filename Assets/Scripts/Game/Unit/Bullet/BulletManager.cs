using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletStatus))]
public class BulletManager : MonoBehaviour
{
    public BulletMovementSimple bulletMovement;
    public BulletStatus bulletStatus;

    public List<BuffCore> bulletsBuffList = new List<BuffCore>();
}
