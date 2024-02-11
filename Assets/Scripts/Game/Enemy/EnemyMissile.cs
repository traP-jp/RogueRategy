using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMissile : MonoBehaviour
{
    //親オブジェクト
    [SerializeField] Transform parentTransform;
    //ユニットの通過経路
    [SerializeField] private List<EnemyPath> enemyPaths;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Movement()
    {
        foreach (var enemyPath in enemyPaths)
        {
        transform.DOLocalPath(
        path     : enemyPath.GetWayPoints(), //移動するポイント
        duration : enemyPath.GetMoveTime()[0], //移動時間
        pathType : PathType.CatmullRom //移動するパスの種類
        ).SetEase(Ease.OutCubic)
        .OnComplete(SetPosition);
        yield return new WaitForSeconds(3);
        }
    }
    //座標を親オブジェクトに渡してこのオブジェクトの座標をリセットする
    public void SetPosition(){
        parentTransform.position += this.transform.localPosition;
        this.transform.localPosition = new Vector3(0, 0, 0);

    }
}
