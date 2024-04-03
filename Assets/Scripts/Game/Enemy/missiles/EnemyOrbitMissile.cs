using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
public class EnemyOrbitMissile : EnemyMissile, IOrbit
{
    
    [SerializeField] string orbitPoolName;
    //軌道用のオブジェクトのpool
    Transform orbitPool;
    //軌道用オブジェクト
    [SerializeField] GameObject orbit;
    //軌道の間隔時間
    [SerializeField] float fadeTime;
    float timer = 0f;
    // Start is called before the first frame update
    public override void OnEnable()
    {
        base.OnEnable();
        //プールを探す
        orbitPool = GameObject.Find(orbitPoolName)?.transform;
        if(orbit != null){
            GameObjectPool(orbitPool,this.transform.position,this.transform.rotation,orbit);
        }
        
        Movement();
    }
    // Update is called once per frame
    void Update()
    {
        //軌道を一定時間ごとに生成
        timer += Time.deltaTime;
        if(timer >= fadeTime && orbit != null){
            timer = 0f;
        GameObjectPool(orbitPool,this.transform.position,this.transform.rotation,orbit);
        }
    }
    //オブジェクトプールの処理
    public void GameObjectPool(Transform pool,Vector3 vector3,Quaternion quaternion,GameObject missile){
        bool isPoolHave = false;
        foreach(Transform t in pool) {
            //オブジェが非アクティブなら使い回し
            if( ! t.gameObject.activeSelf){ 
                t.SetPositionAndRotation(vector3,quaternion); 
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                isPoolHave = true;
                break;
            } 
        } 
        if(!isPoolHave){
            //非アクティブなオブジェクトがないなら生成
            Instantiate(missile, vector3, quaternion,pool);
        }
    }
}

