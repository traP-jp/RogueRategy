using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;
using Game.UI;

public class PrepareSceneManager : MonoBehaviour
{
    [SerializeField] private DestinationManager destinationManager;
    //操作用のクラス。具体的な処理はインターフェイスをセットして行う
    [SerializeField] private DestinationController destinationController;
    [SerializeField] private PhaseUIManager phaseUIManager;
    [SerializeField] private DeckMenu deckMenu;
    IDestinationEventInterface _DestinationEventInterface;
    GameInputs _gameInputs;
    
    int phase = 0;
    int maxPhase = 5;
    bool isDeckMenuOpen = false;

    void Start()
    {
        _gameInputs = new GameInputs();
        _gameInputs.PrepareScene.Enable();
        destinationManager.OnDestinationDecide += DecideDestination;
        _gameInputs.PrepareScene.Menu.performed += SetDeckMenuOpen;
        destinationController.SetPrepareSceneInterface((IPrepareSceneInterface)destinationManager);
        destinationController.Enable(_gameInputs);
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

    //デッキメニューを開いているときに、デッキメニューを閉じる
    public void SetDeckMenuOpen(InputAction.CallbackContext context){
        if (!isDeckMenuOpen)
        {
            destinationController.Disable();
            deckMenu.OpenDeckMenu(_gameInputs);
            isDeckMenuOpen = true;
        }
        else
        {
            deckMenu.CloseDeckMenu();
            destinationController.Enable(_gameInputs);
            isDeckMenuOpen = false;
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
