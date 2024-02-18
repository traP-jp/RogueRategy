using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyPaths", menuName = "RogueRategy/EnemyPaths", order = 0)]
public class EnemyPaths : ScriptableObject
{
    // Start is called before the first frame update
   [SerializeField] EnemyPath[] enemyPaths;
   public EnemyPath[] SetEnemyPaths(){
    return enemyPaths;
   }
}
