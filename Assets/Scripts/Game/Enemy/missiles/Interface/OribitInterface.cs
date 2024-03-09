
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IOrbit{
        //軌道用のオブジェクトの取得
    
        //バフを受けることができるキャラにつける
        void GameObjectPool(Transform pool,Vector3 vector3,Quaternion quaternion,GameObject missile);
}


