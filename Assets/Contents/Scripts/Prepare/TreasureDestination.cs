using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDestination : MonoBehaviour , IDestinationEventInterface,IPrepareSceneInterface
{
    public event System.Action OnDestinationEvent;
    void IDestinationEventInterface.StartthisDestination()
    {
        Debug.Log("Treasure");
    }
    public void EndthisDestination()
    {
        OnDestinationEvent.Invoke();
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