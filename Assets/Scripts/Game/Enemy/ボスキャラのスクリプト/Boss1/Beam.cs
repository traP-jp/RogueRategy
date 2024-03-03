using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
public class Beam : MonoBehaviour
{
    // Start is called before the first frame update
    bool canAttack;
    [SerializeField] float whenStart;
    [SerializeField] float whenEnd;
    async UniTask Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(whenStart));
        await UniTask.Delay(TimeSpan.FromSeconds(whenEnd));
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
