using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using Cysharp.Threading.Tasks;
using System.Threading;
using DG.Tweening;
public class Boss1 : MonoBehaviour
{
    private float bossSpeed = 0.002f;
    [SerializeField] private BossPart bossBodyPart;
    [SerializeField] private BossPart bossPart1;
    bool isBossPart1Broken = false;
    [SerializeField] private BossPart bossPart2;
    bool isBossPart2Broken = false;
    [SerializeField] private GameObject player;
    //レーザー発射の時間管理
    [SerializeField] private int laserTime;
    int laserTimer;
    // Start is called before the first frame update
    //レーザー発射イベントのインスタンス
    private Subject<int> LaserTimerSubject = new Subject<int>();
    public IObservable<int> OnLaserTimeChanged
    {
        get { return LaserTimerSubject; }
    } 
    //ビーム発射の時間管理
    [SerializeField] private int beamTime;
    int beamTimer;
    // Start is called before the first frame update
    //ビーム発射イベントのインスタンス
    private Subject<int> beamTimerSubject = new Subject<int>();
    public IObservable<int> OnBeamTimeChanged
    {
        get { return beamTimerSubject; }
    } 
    
    async UniTaskVoid Start()
    {
        var stopBeam = Observable.EveryUpdate().Where(_ => isBossPart1Broken && isBossPart2Broken);
        var token = this.GetCancellationTokenOnDestroy();
        this.OnLaserTimeChanged.Subscribe(_ =>{LaserShot(token);});
        this.OnBeamTimeChanged.TakeUntil(stopBeam).Subscribe(_ =>{BeamShot(token);});
        //パーツの破壊処理
        bossPart1.OnPartBrokenObservable.Subscribe(_ => {CheckBrokenPart();});
        bossPart2.OnPartBrokenObservable.Subscribe(_ => {CheckBrokenPart();});

    }
    // Update is called once per frame
    void Update()
    {

        if(player.GetComponent<Transform>().position.y <= transform.position.y){
            transform.position -= new Vector3(0,bossSpeed,0);
        }
        else{
            transform.position += new Vector3(0,bossSpeed,0);
        }
        //機体の移動
        laserTimer += 1;
        beamTimer +=1;
        if(laserTimer > laserTime){
            laserTimer = 0;
            LaserTimerSubject.OnNext(laserTimer);
        }
        if(beamTimer > beamTime){
            beamTimer = 0;
            beamTimerSubject.OnNext(beamTimer);
        }
    }
    public void CheckBrokenPart(){
        isBossPart1Broken = bossPart1.GetIsBroken();
        isBossPart2Broken = bossPart2.GetIsBroken();
        if(isBossPart1Broken && isBossPart2Broken){
            bossSpeed = 0.005f;
        }


    }
    async UniTask LaserShot(CancellationToken token){
        bossBodyPart.ShotMissile(0,0,false);
        bossBodyPart.ShotMissile(0,1,false);
    }
    async UniTask BeamShot(CancellationToken token){
        
        if(player.GetComponent<Transform>().position.y <= transform.position.y){
            if(!isBossPart1Broken){
                bossPart1.ShotMissile(0,0,true);
            }
            else{
                bossPart2.ShotMissile(0,0,true);
            }
            transform.DOMove(new Vector3(0, -1.5f, 0),2f).SetEase(Ease.InOutBack).SetRelative(true);
          
        }
        else{
            
            if(!isBossPart2Broken){
                bossPart2.ShotMissile(0,0,true);
            }
            else{
                bossPart1.ShotMissile(0,0,true);
            }
            transform.DOMove(new Vector3(0, 1.5f, 0),2f).SetEase(Ease.InOutBack).SetRelative(true);
        }
    }
}
