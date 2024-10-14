using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DestinationManager : MonoBehaviour,IPrepareSceneInterface
{
    //選択肢の数
    private int _destinationCount = 3;
    enum DestinationType{
        Battle,// = 0
        CardShop,// = 1
        EnhanceShop,// = 2
        Fix,// = 3
        Treasure,// = 4
        
    }
    [SerializeField] Sprite[] _destinationImages;
    [SerializeField] GameObject _destinationObjectUI;
    private DestinationType[] _destinationTypes = new DestinationType[3];
    [SerializeField] Vector3 _basePosition;
    [SerializeField] float _horizonInterval;
    DestinationViewUI[] _destinationViewUIs = new DestinationViewUI[3];
    int choosePoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        ShowNormalDestinations();
    }
    public void ShowNormalDestinations(){
        List<int> ChooseType = new List<int>(){0, 1, 2, 3, 4};
        for(int i = 0; i < _destinationCount; i++){
            Vector3 position = _basePosition + new Vector3(_horizonInterval * i, 0, 0);
            //オブジェクトを子オブジェクトとして生成
            GameObject destinationObject = Instantiate(_destinationObjectUI, position, Quaternion.identity);
            destinationObject.transform.SetParent(this.transform, false);
            //選択肢の種類をランダムで決定.ただし、同じ選択肢がでないようにする
            int type = ChooseType[Random.Range(0, ChooseType.Count)];
            Debug.Log(type);
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
        if(choosePoint < _destinationCount - 1){
            choosePoint++;
        }
        SetCardSize();
    }
    public void OnLeft(){
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
        for(int i = 0; i < _destinationCount; i++){
            if(i == choosePoint){
                _destinationViewUIs[i].UseThisCardAnimation();
            }else{
                _destinationViewUIs[i].CleanThisCardAnimation();
            }
        }
        //選択した選択肢によって処理を変える
        switch(_destinationTypes[choosePoint]){
            case DestinationType.Battle:
                Debug.Log("Battle");
                break;
            case DestinationType.CardShop:

                Debug.Log("CardShop");
                break;
            case DestinationType.EnhanceShop:
                Debug.Log("EnhanceShop");
                break;
            case DestinationType.Fix:
                Debug.Log("Fix");
                break;
            case DestinationType.Treasure:
                Debug.Log("Treasure");
                break;
        }
    }
    public void OnUp(){
        //上にスライド
    }
    public void OnDown(){
        //下にスライド
    }
    
}
