using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class EnemySpawner : MonoBehaviour
{
    public List<EnemyWave> waves;
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
              for(int j = 0; j < wave.horizonalEnemyNumber;j++){
                   for(int k = 0;k < wave.horizonalEnemyNumber;k++){
                    //enemyをインスタンス化する(生成する)
                    GameObject enemyObject = Instantiate(wave.enemyType);
                    Enemy enemy = enemyObject.GetComponentInChildren<Enemy>();
                    Debug.Log(enemy);
                    enemy.SetEnemyPaths(wave.paths);
                    enemy.Movement();
                    //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
                    Vector3 vector3 = new Vector3(wave.interval.x*j,wave.interval.y*k,0);
                    enemyObject.transform.position = wave.spawnPoint + vector3;

                }

            }
            await UniTask.Delay((int)(wave.spawnTime*1000));
            Debug.Log("33434");
                
        }
    }
  }
