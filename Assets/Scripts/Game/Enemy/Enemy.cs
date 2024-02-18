using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour 
{
    [SerializeField] UnityEngine.UI.Slider enemyHPSlider;
    //ユニットの通過経路
    private EnemyPaths enemyPaths;
    public void SetEnemyPaths(EnemyPaths enemyPaths){
        this.enemyPaths = enemyPaths;
    }
    [SerializeField] int maxHP = 1000;
    [SerializeField] int nowHP = 1000;
    //死亡判定
    bool deadflag = false;
    //親オブジェクト
    [SerializeField] Transform parentTransform;
    //弾丸の種類
    [SerializeField] List<GameObject> missile;
    //攻撃の待機時間
    [SerializeField] int waitTime;
    //攻撃から経った時間　
    int time = 0;
    //攻撃が可能か
    bool canAttack = true;

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
            enemyHPSlider.value = nowHPProperty / (float)maxHP;
        }
    }
    //倒された時の処理
    public void Deathmotion()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    //移動処理
    public async UniTaskVoid Movement()
    {
        EnemyPath[] paths = enemyPaths.SetEnemyPaths();
        foreach (var enemyPath in paths)
        {
        transform.DOLocalPath(
        path     : enemyPath.GetWayPoints(), //移動するポイント
        duration : enemyPath.GetMoveTime(), //移動時間
        pathType : PathType.CatmullRom //移動するパスの種類
        ).SetEase(Ease.OutCubic)
        .OnComplete(SetPosition);
        await UniTask.Delay(enemyPath.GetWaitTime());
        }
    }
    //座標を親オブジェクトに渡してこのオブジェクトの座標をリセットする
    public void SetPosition(){
        parentTransform.position += this.transform.localPosition;
        this.transform.localPosition = new Vector3(0, 0, 0);

    }
    //攻撃の処理
    public void Attack(){
        time += 1;
        if (time >= waitTime){
            time = 0;
            Instantiate(missile[0], this.transform.position, Quaternion.identity);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
