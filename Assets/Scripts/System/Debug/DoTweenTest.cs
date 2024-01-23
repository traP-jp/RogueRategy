#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace ForTesting
{
    public class DoTweenTest : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            this.transform.DOMove(new Vector3(5f, 0f, 0f), 3f)
                          .SetEase(Ease.InOutQuart);
        }


    }
}

#endif