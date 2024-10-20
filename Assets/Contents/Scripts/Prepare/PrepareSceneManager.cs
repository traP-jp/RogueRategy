using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class PrepareSceneManager : MonoBehaviour
{
    [SerializeField] private DestinationManager destinationManager;
    //操作用のクラス。具体的な処理はインターフェイスをセットして行う
    [SerializeField] private DestinationController destinationController;
    [SerializeField] private PhaseUIManager phaseUIManager;
    IDestinationEventInterface _DestinationEventInterface;
    int phase = 0;
    int maxPhase = 5;
    void Start()
    {
        destinationManager.OnDestinationDecide += DecideDestination;
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)destinationManager);
        destinationManager.ShowNormalDestinations();
        phaseUIManager.MakePhaseUI(maxPhase);
    }

    //次のフェーズに進む
    public void NextPhase(){
        
        _DestinationEventInterface.OnDestinationEvent -= NextPhase;
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)destinationManager);
        phase++;
        destinationManager.ShowNormalDestinations();
        phaseUIManager.MovePointer(phase);
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            NextPhase();
        }
    }
    //行先を決定したときの処理
    public void DecideDestination(){
        switch (destinationManager.ChooseDestination)
        {
            case DestinationManager.DestinationType.Battle:
                Debug.Log("Battle");
                break;
            case DestinationManager.DestinationType.CardShop:
                Debug.Log("CardShop");
                _DestinationEventInterface = GetComponentInChildren<CardShopDestination>();
                break;
            case DestinationManager.DestinationType.EnhanceShop:
                Debug.Log("EnhanceShop");
                _DestinationEventInterface = GetComponentInChildren<EnhanceShopDestination>();
                break;
            case DestinationManager.DestinationType.Fix:
                Debug.Log("Fix");
                _DestinationEventInterface = GetComponentInChildren<FixDestination>();
                break;
            case DestinationManager.DestinationType.Treasure:
                Debug.Log("Treasure");
                _DestinationEventInterface = GetComponentInChildren<TreasureDestination>();
                break;
            default:
                break;
        }
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)_DestinationEventInterface);
        _DestinationEventInterface.OnDestinationEvent += NextPhase;
        _DestinationEventInterface.StartthisDestination();
                
    }

}
