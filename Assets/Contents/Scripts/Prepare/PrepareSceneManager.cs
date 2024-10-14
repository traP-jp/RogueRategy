using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareSceneManager : MonoBehaviour
{
    [SerializeField] private DestinationManager destinationManager;
    [SerializeField] private DestinationController destinationController;
    void Start()
    {
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)destinationManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
