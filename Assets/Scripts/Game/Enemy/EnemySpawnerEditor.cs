using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EnemySpawner spawner = (EnemySpawner)target;

        for (int i = 0; i < spawner.waves.Count; i++)
        {
            EditorGUILayout.LabelField("Wave " + (i + 1));
            spawner.waves[i].horizonalEnemyNumber = EditorGUILayout.IntField("H_Enemy Number", spawner.waves[i].horizonalEnemyNumber);
            spawner.waves[i].verticalEnemyNumber = EditorGUILayout.IntField("V_Enemy Number", spawner.waves[i].verticalEnemyNumber);
            spawner.waves[i].spawnPoint = EditorGUILayout.Vector3Field("Spawn Point", spawner.waves[i].spawnPoint);
            spawner.waves[i].interval = EditorGUILayout.Vector3Field("Enemy Number", spawner.waves[i].interval);
            spawner.waves[i].enemyType = (GameObject)EditorGUILayout.ObjectField("Enemy Type", spawner.waves[i].enemyType, typeof(GameObject), false);
            spawner.waves[i].spawnTime = EditorGUILayout.FloatField("Spawn Time", spawner.waves[i].spawnTime);
            spawner.waves[i].paths = (EnemyPaths)EditorGUILayout.ObjectField("Paths", spawner.waves[i].paths, typeof(EnemyPaths), false);
            
            
        }

        if (GUILayout.Button("Add Wave"))
        {
            spawner.waves.Add(new EnemyWave());
        }

        if (GUILayout.Button("Remove Last Wave") && spawner.waves.Count > 0)
        {
            spawner.waves.RemoveAt(spawner.waves.Count - 1);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(spawner);
        }
    }
}
