using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening;
public class BossPart : Enemy,IBossPart

{
    //ミサイルの発射場所
    [SerializeField] private List<Transform> missilePort;
    //ミサイル
    [SerializeField] private List<GameObject> missiles;
    //破壊されたかどうか
    public bool isbroken = false;
    private Subject<bool> partBrokenSubject = new Subject<bool>();
    public IObservable<bool> OnPartBrokenObservable => partBrokenSubject;

    public bool GetIsBroken(){
        return isbroken;
    }
    // Start is called before the first frame update

    void Update()
    {
   
    }
    //ショット
    public void ShotMissile(int missileNum,int missilePortNum,bool isObjectParent ){
        GameObject Obj;
        Obj = Instantiate(missiles[missileNum], missilePort[missilePortNum].transform.position, Quaternion.identity);
        if(isObjectParent){
            Obj.transform.parent = transform;
        }
    }
    public void BrokenEffect(){
        isbroken = true;
        partBrokenSubject.OnNext(true);
    }

}
