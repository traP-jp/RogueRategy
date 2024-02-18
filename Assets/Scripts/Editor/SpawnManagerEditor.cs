using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyPath))]
public class SpawnManagerEditor : Editor
{
    private EnemyPath enemyPath;

    private void OnEnable()
    {
        enemyPath = (EnemyPath)target;
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
    private void OnSceneGUI()
    {
        if (enemyPath.GetWayPoints() == null) return;

        Handles.color = Color.red;
        Handles.DrawLines(enemyPath.GetWayPoints());
    }
}


