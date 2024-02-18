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
    [SerializeField] private List<EnemyPath> enemyPaths;
    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async UniTaskVoid Movement()
    {
        foreach (var enemyPath in enemyPaths)
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
}
