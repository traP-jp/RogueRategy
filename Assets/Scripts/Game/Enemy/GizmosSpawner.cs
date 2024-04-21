using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
public class GizmosSpawner : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;
   void OnDrawGizmosSelected()
    {
        
        // エディターのインスタンスが null でないことを確認
        if (spawner != null)
        {
            // 'spawner' プロパティをエディターのインスタンスを介してアクセス
            int nowChangingPlace = spawner.nowChangingPlace;
            Gizmos.color = Color.red;
            for(int j = 0; j < spawner.waves[nowChangingPlace].moveRoutes.Count(); j++){
                EnemyWave.EnemyRoute moveRoute = spawner.waves[nowChangingPlace].moveRoutes[j];
                var count = moveRoute.RoutePoint.Count;
                for (var index = 0; index < count -1; index++)
                {
                    var next = index + 1;
                    var start = moveRoute.RoutePoint[index];
                    var end = moveRoute.RoutePoint[next];
                    Gizmos.DrawLine(start, end);
                }
            }
        }
        else
        {
            // エディターのインスタンスが見つからなかった場合の処理（例：エラーメッセージの表示）
            Debug.LogError("EnemySpawnerEditor のインスタンスがシーン内で見つかりませんでした。");
        }
       
        
    }
}
