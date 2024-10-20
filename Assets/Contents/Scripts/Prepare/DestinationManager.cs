using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class DestinationManager : MonoBehaviour,IPrepareSceneInterface
{

    public event Action OnDestinationDecide;
    //選択肢の数
    private int _destinationCount = 3;
    public enum DestinationType{
        Battle,// = 0
        CardShop,// = 1
        EnhanceShop,// = 2
        Fix,// = 3
        Treasure,// = 4
        
    }
    [SerializeField] Sprite[] _destinationImages;
    [SerializeField] GameObject _destinationObjectUI;
    private DestinationType[] _destinationTypes = new DestinationType[3];
    private DestinationType chooseDestination = 0;
    public DestinationType ChooseDestination{
        get{
            return chooseDestination;
        }
    }
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
            GameObject destinationObject = Instantiate(_destinationObjectUI, position, Quaternion.identity);
            destinationObject.transform.SetParent(this.transform, false);
            //選択肢の種類をランダムで決定.ただし、同じ選択肢がでないようにする
            int type = ChooseType[UnityEngine.Random.Range(0, ChooseType.Count)];
            _destinationTypes[i] = (DestinationType)type;
            ChooseType.Remove(type);
            
            DestinationViewUI destinationViewUI = destinationObject.GetComponent<DestinationViewUI>();
            destinationViewUI.SetCardView(_destinationImages[type]);
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
                _destinationViewUIs[i].UseThisCardAnimation();
            }else{
                _destinationViewUIs[i].CleanThisCardAnimation();
            }
        }
        chooseDestination = _destinationTypes[choosePoint];
        OnDestinationDecide?.Invoke();
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
