using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "EnemyPath", menuName = "RogueRategy/EnemyPath", order = 0)]
public class EnemyPath : ScriptableObject 
{
    //通過地点
    [SerializeField] Vector3[] wayPoints;
    public Vector3[] GetWayPoints(){
        return wayPoints;
    }
    //各通過地点への移動時間
    [SerializeField] float moveTime;
    public float GetMoveTime(){
        return moveTime;
    }
    
    
    [SerializeField]DG.Tweening.Ease ease;
    public DG.Tweening.Ease GetEase(){
        return ease;
    }
}
