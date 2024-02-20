using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletStatus))]
public class BulletManager : MonoBehaviour
{
    public IBulletMovement bulletMovement;
    public BulletStatus bulletStatus;

    public List<BuffCore> bulletsBuffList = new List<BuffCore>();

    private void OnEnable()
    {
        bulletMovement = GetComponent<IBulletMovement>();
    }
}

public interface IBulletMovement
{
    void Initialize(float speed);
}
