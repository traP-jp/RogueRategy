using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    //ギズモの描写用
    

    EnemySpawner spawner;
    List<bool> isOpens = Enumerable.Repeat(true, 999).ToList();
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("All Open"))
        {
            isOpens = Enumerable.Repeat(true, 999).ToList();
        }
        if (GUILayout.Button("All Close"))
        {
            isOpens = Enumerable.Repeat(false, 999).ToList();
        }
        spawner = (EnemySpawner)target;
        for (int i = 0; i < spawner.waves.Count; i++)
        {
            
            isOpens[i] = EditorGUILayout.BeginFoldoutHeaderGroup(isOpens[i], "Wave " + (i + 1) );
            if (isOpens[i])
            {   
                var color = GUI.backgroundColor;
                GUI.backgroundColor = Color.blue;
                using(new EditorGUILayout.VerticalScope("Box", GUILayout.ExpandWidth(true)))
                {
                    EditorGUI.BeginChangeCheck();
                    spawner.waves[i].canExpressMark = EditorGUILayout.Toggle("Spawn Time", spawner.waves[i].canExpressMark);
                    spawner.waves[i].enemyType = (GameObject)EditorGUILayout.ObjectField("Enemy Type", spawner.waves[i].enemyType, typeof(GameObject), false);
                    spawner.waves[i].spawnTime = EditorGUILayout.FloatField("Spawn Time", spawner.waves[i].spawnTime);
                    spawner.waves[i].otherEnemy = (EnemyWave.OtherEnemy)EditorGUILayout.EnumPopup("OtherEnemy", spawner.waves[i].otherEnemy);
                    //Lineの場合
                    if(spawner.waves[i].otherEnemy == EnemyWave.OtherEnemy.line){
                        spawner.waves[i].horizonalEnemyNumber = EditorGUILayout.IntField("H_Enemy Number", spawner.waves[i].horizonalEnemyNumber);
                        spawner.waves[i].verticalEnemyNumber = EditorGUILayout.IntField("V_Enemy Number", spawner.waves[i].verticalEnemyNumber);
                        spawner.waves[i].interval = EditorGUILayout.Vector3Field("EnemyInterval", spawner.waves[i].interval);
                    }
                    //Followの場合
                    if(spawner.waves[i].otherEnemy == EnemyWave.OtherEnemy.follow){
                        spawner.waves[i].spawnNumber = EditorGUILayout.IntField("SpawnNumber", spawner.waves[i].spawnNumber);
                        spawner.waves[i].spawnIntervalTime = EditorGUILayout.FloatField("IntervalTime", spawner.waves[i].spawnIntervalTime);
                    }
                    spawner.waves[i].enemyMovementType = (EnemyWave.EnemyMovementType)EditorGUILayout.EnumPopup("EnemyMovementTime", spawner.waves[i].enemyMovementType);
                    //Routeの場合
                    if(spawner.waves[i].enemyMovementType == EnemyWave.EnemyMovementType.Route){
                        if (GUILayout.Button("Connect Routes"))
                        {
                            for(int j = 0; j < spawner.waves[i].moveRoutes.Count()-1; j++){
                                int pointCount =  spawner.waves[i].moveRoutes[j].RoutePoint.Count();
                                spawner.waves[i].moveRoutes[j].RoutePoint[pointCount-1] = spawner.waves[i].moveRoutes[j+1].RoutePoint[0] ;
                            }
                        }
                        for(int j = 0; j < spawner.waves[i].moveRoutes.Count(); j++){
                            EnemyWave.EnemyRoute moveRoute = spawner.waves[i].moveRoutes[j];
                            // ルートリストの表示
                            for(int k = 0; k < moveRoute.RoutePoint.Count();k++)
                            {
                                moveRoute.RoutePoint[k] = EditorGUILayout.Vector3Field("",moveRoute.RoutePoint[k]);
                            }
                            //ルートリストの追加
                            if (GUILayout.Button("Add Point"))
                                {
                                moveRoute.RoutePoint.Add(new Vector3(0f,0f,0f));
                                }
                            if (GUILayout.Button("Remove Point"))
                                {
                                moveRoute.RoutePoint.RemoveAt(spawner.waves.Count - 1);
                                }
                        moveRoute.ease = (DG.Tweening.Ease)EditorGUILayout.EnumPopup("EnemyMovementTime", moveRoute.ease);
                        moveRoute.movetime = EditorGUILayout.FloatField("MoveTime",moveRoute.movetime);
                        moveRoute.waitTime = EditorGUILayout.FloatField("WaitTime",moveRoute.waitTime);
                        spawner.waves[i].loopPoint = EditorGUILayout.IntField("LoopRoute",spawner.waves[i].loopPoint);
                            
                        GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
                        }
                        
                        if (GUILayout.Button("Add Route"))
                            {
                            spawner.waves[i].moveRoutes.Add(new EnemyWave.EnemyRoute());
                            }
                        if (GUILayout.Button("Remove Route"))
                                {
                                spawner.waves[i].moveRoutes.RemoveAt(spawner.waves.Count - 1);
                                }
                    }
                    //変化しているかの処理
                    if (EditorGUI.EndChangeCheck())
                    {
                        spawner.nowChangingPlace = i;

                    }
                    //spawner.waves[i].spawnPoint = EditorGUILayout.Vector3Field("Spawn Point", spawner.waves[i].spawnPoint);
                    
                    GUI.backgroundColor = color;
                    GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
                }
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            
        }

        if (GUILayout.Button("Add Wave"))
        {
            spawner.waves.Add(new EnemyWave());
            isOpens[spawner.waves.Count-1] = true;
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
    private EnemySpawner EnemySpawner => target as EnemySpawner;
    
}