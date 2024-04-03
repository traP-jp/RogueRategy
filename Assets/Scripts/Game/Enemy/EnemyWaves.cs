using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
[System.Serializable]
public class EnemyWave
{
    //経路の表示用のスクリプト
    public bool canExpressMark = false;
    //複数敵を出現させるときに並ばせるか、列を作るか
    public enum OtherEnemy{
        line,
        follow
    }
    public OtherEnemy otherEnemy = OtherEnemy.line;
    //line用
    public int horizonalEnemyNumber = 1;
    public int verticalEnemyNumber = 1;
    public Vector3 interval;
    //follow用
    public float spawnIntervalTime;
    public int spawnNumber;

    //移動のタイプ
    public enum EnemyMovementType{
        Route,
        Tracking
    }
    public EnemyMovementType enemyMovementType = EnemyMovementType.Route;
    //Routeだと表示するもの
    public List<EnemyRoute> moveRoutes = new List<EnemyRoute>();
    [System.Serializable]
    public class EnemyRoute { // 内部クラス

        public List<Vector3> RoutePoint = new List<Vector3>();

        public float movetime = 0f;
        //次の移動への待ち時間
        public float waitTime = 0f;
        public DG.Tweening.Ease ease;
    }
    //何番目からループさせるか
    public int loopPoint = 0;
    
    public GameObject enemyType;
    public float spawnTime;
}

