using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class EnemyWave
{
    public int horizonalEnemyNumber = 1;
    public int verticalEnemyNumber = 1;
    public Vector3 spawnPoint;
    public Vector3 interval;
    public GameObject enemyType;
    public float spawnTime;
    public EnemyPaths paths;
}

