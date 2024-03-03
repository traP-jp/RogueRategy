using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour 
{
    
    [SerializeField] Transform missilePool;
    [SerializeField] UnityEngine.UI.Slider enemyHPSlider;
    //ユニットの通過経路
    [SerializeField] private EnemyPaths enemyPaths;
    public void SetEnemyPaths(EnemyPaths enemyPaths){
        this.enemyPaths = enemyPaths;
    }
    //敵の軌道作成用
    public EnemyPath[] paths;
    [SerializeField] int maxHP = 1000;
    [SerializeField] int nowHP = 1000;
    //弾丸の種類
    [SerializeField] List<GameObject> missile;
    //攻撃の待機時間
    [SerializeField] int waitTime;
    //攻撃から経った時間　
    int time = 0;
    //移動処理が完了したか
    bool isContinueMove = true;
    //警戒線とそのプール
    [SerializeField] GameObject cordon;
    [SerializeField] Transform cordonPool;
    int nowHPProperty
    {
        get { return nowHP; }
        set
        {
            if (value <= 0)
            {
                //エネミーを消す処理
            }
            else if (value > maxHP)
            {
                nowHP = maxHP;
                throw new System.ArgumentOutOfRangeException();
            }
            else nowHP = value;
        }
    }

    
    //ダメージ処理
    public void AddDamage(int strength)
    {
        Debug.Log(strength + "ダメージ");
        try
        {
            nowHPProperty -= strength;
        }
        catch
        {

        }
        finally
        {
            //enemyHPSlider.value = nowHPProperty / (float)maxHP;
        }
    }
    //倒された時の処理
    public void Deathmotion()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
       Movement(0).Forget();
    }
    //移動処理
    public async UniTaskVoid Movement(int loopPoint)
    {
        if(enemyPaths != null){
            paths = enemyPaths.SetEnemyPaths();
            for(int i = loopPoint; i < paths.Length;i++)
            {
            transform.DOLocalPath(
                path     : paths[i].GetWayPoints(), //移動するポイント
                duration : paths[i].GetMoveTime(), //移動時間
                pathType : PathType.CatmullRom //移動するパスの種類
                ).SetEase(paths[i].GetEase()).OnComplete(SetPosition).SetRelative(true);
            await UniTask.WaitWhile(() => isContinueMove);
            isContinueMove = true;
            await UniTask.Delay(enemyPaths.GetWaitTime(i));
            }
            if(enemyPaths.GetIsLoop()){
            Movement(enemyPaths.GetLoopPoint()).Forget();
            }
        }
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
    //被弾処理
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(nowHPProperty);
        BulletStatus bulletStatus = other.gameObject.GetComponent<BulletStatus>();
        AddDamage((int)bulletStatus.GetDamage());
        Destroy(other.gameObject);
    }    
    void Update()
    {
        time += 1;
        if (time >= waitTime){
            time = 0;
            Attack();
        }
    }
    public void BrokenEffect(){

    }
}
