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
        if(bulletMovement == null)
        {
            bulletMovement = GetComponent<IBulletMovement>();
        }
        
    }

    private void Reset()
    {
        bulletMovement = GetComponent<IBulletMovement>();
        bulletStatus = GetComponent<BulletStatus>();
    }
}

public interface IBulletMovement
{
    void Initialize(float speed);
}
