using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;

public class EnhanceShopDestination : MonoBehaviour,IDestinationEventInterface,IPrepareSceneInterface
{
    public event System.Action OnDestinationEvent;
    private int _destinationCount = 3;
    [SerializeField] GameObject _EnhanceCardUI;
    [SerializeField] GameObject _ChooseEnhanceUIs;
    [SerializeField] private PlayerInfoData _playerInfo;
    void IDestinationEventInterface.StartthisDestination()
    {
        ShowNormalDestinations();
        
    }
    public void EndthisDestination()
    {
        OnDestinationEvent.Invoke();
    }
    // Start is called before the first frame update
    [SerializeField] Vector3 _basePosition;
    [SerializeField] float _horizonInterval;
    DestinationViewUI[] _destinationViewUIs = new DestinationViewUI[3];
    int choosePoint = 0;
    bool isDecide = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ShowNormalDestinations(){
        //子オブジェクトを全削除
        foreach(Transform n in this.transform){
            Destroy(n.gameObject);
        }
        isDecide = false;
        choosePoint = 0;
        List<int> ChooseType = new List<int>(){0, 1, 2, 3, 4};
        for(int i = 0; i < _destinationCount; i++){
            Vector3 position = _basePosition + new Vector3(_horizonInterval * i, 0, 0);
            //オブジェクトを子オブジェクトとして生成
            GameObject destinationObject = Instantiate(_EnhanceCardUI, position, Quaternion.identity);
            DestinationViewUI destinationViewUI = destinationObject.GetComponent<DestinationViewUI>();
            destinationObject.transform.SetParent(_ChooseEnhanceUIs.transform, false);
            destinationViewUI.SetCardView(null);
            _destinationViewUIs[i] = destinationViewUI;

        }
        SetCardSize();
    }
    public void OnRight(){
        //右にスライド
        if(isDecide){
            return;
        }
        if(choosePoint < _destinationCount - 1){
            choosePoint++;
        }
        SetCardSize();
    }
    public void OnLeft(){
        if(isDecide){
            return;
        }
        //左にスライド
        if(choosePoint > 0){
            choosePoint--;  
        }
        SetCardSize();
    }
    public void SetCardSize(){
        for(int i = 0; i < _destinationCount; i++){
            if(i == choosePoint){
                _destinationViewUIs[i].ChooseCard();
            }else{
                _destinationViewUIs[i].UnChooseCard();
            }
        }
    }
    public void OnDecide(){
        if(isDecide){
            return;
        }
        isDecide = true;
        for(int i = 0; i < _destinationCount; i++){
            if(i == choosePoint){
                //選んだカードのアニメーション
                _destinationViewUIs[i].UseThisCardAnimation();
            }else{
                //選んでいないカードのアニメーション
                _destinationViewUIs[i].CleanThisCardAnimation();
            }
        }
        EndthisDestination();
        //選択した選択肢によって処理を変える
        // switch(_destinationTypes[choosePoint]){
        //     case DestinationType.Battle:
        //         Debug.Log("Battle");
        //         break;
        //     case DestinationType.CardShop:
        //         Debug.Log("CardShop");
        //         break;
        //     case DestinationType.EnhanceShop:
        //         Debug.Log("EnhanceShop");
        //         break;
        //     case DestinationType.Fix:
        //         Debug.Log("Fix");
        //         break;
        //     case DestinationType.Treasure:
        //         Debug.Log("Treasure");
        //         break;
        // }
    }
    public void OnUp(){
        //上にスライド
    }
    public void OnDown(){
        //下にスライド
    }
    
}
