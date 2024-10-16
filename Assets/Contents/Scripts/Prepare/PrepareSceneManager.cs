using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PrepareSceneManager : MonoBehaviour
{
    [SerializeField] private DestinationManager destinationManager;
    //操作用のクラス。具体的な処理はインターフェイスをセットして行う
    [SerializeField] private DestinationController destinationController;
    [SerializeField] private PhaseUIManager phaseUIManager;
    int phase = 0;
    int maxPhase = 5;
    void Start()
    {
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)destinationManager);
        destinationManager.ShowNormalDestinations();
        phaseUIManager.MakePhaseUI(maxPhase);
    }

    //次のフェーズに進む
    public void NextPhase(){
        phase++;
        destinationManager.ShowNormalDestinations();
        phaseUIManager.MovePointer(phase);
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            NextPhase();
        }
    }
}
