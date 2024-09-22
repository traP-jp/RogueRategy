using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int nowChangingPlace = 0;
    public List<EnemyWave> waves;
    bool isNextEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async UniTaskVoid EnemySpawn(){
        for(int i = 0; i < waves.Count; i++){
            EnemyWave wave = waves[i];

            if(wave.autoSpawn){
                await UniTask.Delay((int)(wave.spawnTime*1000));            
            }
            else{
                await UniTask.WaitUntil(() => isNextEnemy);
                isNextEnemy = false;
            }
            Debug.Log("Wave" + i + "Start");
            //敵が並ぶ場合
            if (wave.otherEnemy == EnemyWave.OtherEnemy.line){
                for(int j = 0; j < wave.horizonalEnemyNumber;j++){
                    for(int k = 0;k < wave.verticalEnemyNumber;k++){
                        //enemyをインスタンス化する(生成する)
                        GameObject enemyObject = Instantiate(wave.enemyType);
                        Enemy enemy = enemyObject.GetComponentInChildren<Enemy>();
                        enemy.wave = wave;
                        
                        Vector3 vector3 = new Vector3(wave.interval.x*j,wave.interval.y*k,0);
                        enemyObject.transform.position = vector3;

                            //処理変更予定
                            //enemy.SetEnemyPaths(wave.paths);
                            enemy.Movement(0);
                            //生成した敵の座標を決定する
                    }
                }
            }
            //敵が追従する場合
            else if(wave.otherEnemy == EnemyWave.OtherEnemy.follow){
                for(int j = 0;j < wave.spawnNumber;j++) {
                    
                    //enemyをインスタンス化する(生成する)
                    GameObject enemyObject = Instantiate(wave.enemyType);
                    Enemy enemy = enemyObject.GetComponentInChildren<Enemy>();
                    enemy.wave = wave;
                    enemy.Movement(0);
                    await UniTask.Delay((int)(wave.spawnIntervalTime*1000));

                }
            }
            
        }
    }
    //自動スポーンしない時に、次の敵を生成する用のメソッド
    public void CallNExtEnemy(){
        isNextEnemy = true;
    }
}
