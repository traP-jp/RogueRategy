using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyPaths", menuName = "RogueRategy/EnemyPaths", order = 0)]
public class EnemyPaths : ScriptableObject
{
    // Start is called before the first frame update
   [SerializeField] EnemyPath[] enemyPaths;
   
   [SerializeField,TextArea(1,10)] private string informaton;
   public EnemyPath[] SetEnemyPaths(){
    return enemyPaths;
   }
   //次の移動への待ち時間
    [SerializeField] float[] waitTime;
    public int GetWaitTime(int i){
        return (int)(waitTime[i]*1000);
    }
    //ループするかどうか
    [SerializeField] bool isLoop;
    public bool GetIsLoop(){
        return isLoop;
    }
    //何番目からループさせるか
    [SerializeField] int loopPoint = 0;
    public int GetLoopPoint(){
        return loopPoint;
    }
}
