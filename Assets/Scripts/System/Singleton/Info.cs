using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : SingletonMonoBehaviour<Info>
{
    public Transform enemyTransform;

    public Transform bulletParentTransform;//弾丸を生成する親オブジェクトを指定

}
