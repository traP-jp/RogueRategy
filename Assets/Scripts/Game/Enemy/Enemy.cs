using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour 
{
    
    [SerializeField] Transform missilePool;
    //弾丸の種類
    [SerializeField] List<GameObject> missile;
    //攻撃の待機時間
    [SerializeField] int waitTime;
    //攻撃から経った時間　
    int time = 0;
    //移動処理が完了したか
    bool isContinueMove = true;
    bool issearch = false;
    public void SetSearch(){
        issearch = true;
    }
    float speed = 0.01f;
    public void SetSpeed(float speed){
        this.speed = speed;
    }
    
    //警戒線とそのプール
    [SerializeField] GameObject cordon;
    [SerializeField] Transform cordonPool;
    //移動処理用
    public EnemyWave wave{set; get; }
    
    //移動処理
    public async UniTaskVoid Movement(int loopPoint)
    {
        //敵の動きの処理の修正版
        for(int i = loopPoint; i < wave.moveRoutes.Count;i++)
            {
            transform.DOLocalPath(
                path     : wave.moveRoutes[i].RoutePoint.ToArray(), //移動するポイント
                duration : wave.moveRoutes[i].movetime, //移動時間
                pathType : PathType.CatmullRom //移動するパスの種類
                ).SetEase(wave.moveRoutes[i].ease).OnComplete(SetPosition);//.SetRelative(true);
            transform.localPosition = wave.moveRoutes[i].RoutePoint[0];
            await UniTask.WaitWhile(() => isContinueMove);
            isContinueMove = true;
            await UniTask.Delay((int)wave.moveRoutes[i].waitTime);
            }
            if(wave.loopPoint != 0){
                Movement(wave.loopPoint).Forget();
            }
    }
    public void SearchMoveing(){
  
            GameObject player = GameObject.Find("Player");
            Debug.Log(player);
            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = this.transform.position;
            Vector3 direction = playerPos - enemyPos;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos, speed*Time.deltaTime);
    }
    public void SetPosition(){
        isContinueMove = false;
    }
    //攻撃の処理
    public async UniTaskVoid Attack(){
        
        //警戒線の処理
        GameObjectPool(cordonPool,this.transform.position,this.transform.rotation,cordon);
        //暫く待機
        await UniTask.Delay(500);
        //弾発射
        GameObjectPool(missilePool,this.transform.position,this.transform.rotation,missile[0]);
    }
    
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
    void Update()
    {
        time += 1;
        if (time >= waitTime){
            time = 0;
            Attack();
        }
        if(issearch){
            SearchMoveing();
        }
    }
}
