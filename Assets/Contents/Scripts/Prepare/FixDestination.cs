using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class FixDestination : MonoBehaviour,IDestinationEventInterface,IPrepareSceneInterface
{
    public event System.Action OnDestinationEvent;
    ParticleSystem _particleSystem;
    void IDestinationEventInterface.StartthisDestination()
    {
        Fix();
    }
    void EndthisDestination()
    {
        OnDestinationEvent.Invoke();
    }
    public async UniTask Fix(){
        //子オブジェクトからParticleSystemを取得
        _particleSystem = this.GetComponentInChildren<ParticleSystem>();
        //ParticleSystemを再生
        _particleSystem.Play();
        //Unitaskを使って3秒
        await UniTask.Delay(3000);
        EndthisDestination();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLeft(){
        Debug.Log("Left");
    }
    public void OnRight(){
        Debug.Log("Right");
    }
    public void OnUp(){
        Debug.Log("Up");
    }
    public void OnDown(){
        Debug.Log("Down");
    }
    public void OnDecide(){
        Debug.Log("Decide");
    }
}
