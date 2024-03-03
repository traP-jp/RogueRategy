using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
public class EnemyMissile : MonoBehaviour
{
    //親オブジェクト
    [SerializeField] Transform parentTransform;
    //ユニットの通過経路
    [SerializeField] private EnemyPaths enemyPaths;
    public void SetEnemyPaths(EnemyPaths enemyPaths){
        this.enemyPaths = enemyPaths;
    }
    //敵の軌道作成用
    public EnemyPath[] paths;
    bool isContinueMove = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        Movement();
    }
    private void OffActive()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public async UniTaskVoid Movement()
    {
        if(enemyPaths != null){
            paths = enemyPaths.SetEnemyPaths();
            
        }
        
        for(int i = 0; i < paths.Length;i++)
        {
        transform.DOLocalPath(
        path     : paths[i].GetWayPoints(), //移動するポイント
        duration : paths[i].GetMoveTime(), //移動時間
        pathType : PathType.CatmullRom //移動するパスの種類
        ).SetEase(Ease.OutCubic).SetRelative(true)
        .OnComplete(SetPosition);
        await UniTask.WaitWhile(() => isContinueMove);
        isContinueMove = true;
        await UniTask.Delay(enemyPaths.GetWaitTime(i));
        OffActive();
        }
    }
    public void SetPosition(){
        isContinueMove = false;
    }
    //座標を親オブジェクトに渡してこのオブジェクトの座標をリセットする
}
