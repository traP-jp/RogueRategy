using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Game.Card;
using System;
using System.Linq;
using Game.Player;
public class CardShopDestination : MonoBehaviour ,IDestinationEventInterface,IPrepareSceneInterface
{
    public event System.Action OnDestinationEvent;
    private int _destinationCount = 3;
    [SerializeField] GameObject _ChooseCardUI;
    [SerializeField] GameObject _CardUIsObject;
    [SerializeField] private PlayerInfoData _playerInfo;
    //選択のカードの種類
    [SerializeField] private List<CardInfo> _AllCardChoose;
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
    List<CardInfo> _cardChoose;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void ShowNormalDestinations(){
        //表示するカードをランダムに選ぶ
        _cardChoose = new List<CardInfo>(_AllCardChoose);
        _cardChoose = _cardChoose.OrderBy(a => Guid.NewGuid()).ToList();
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
            GameObject destinationObject = Instantiate(_ChooseCardUI, position, Quaternion.identity);
            DestinationViewUI destinationViewUI = destinationObject.GetComponent<DestinationViewUI>();
            destinationObject.transform.SetParent(_CardUIsObject.transform, false);
            destinationViewUI.SetCardView(_cardChoose.ElementAt(i).CardImage);
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
        Debug.Log("SetCardSize");
        for(int i = 0; i < _destinationCount; i++){
            if(i == choosePoint){
                _destinationViewUIs[i].ChooseCard();
            }else{
                _destinationViewUIs[i].UnChooseCard();
            }
        }
    }
    public async UniTask Wait(){
        await UniTask.Delay(3000);
    }
    public void OnDecide(){
        if(isDecide){
            return;
        }
        isDecide = true;
        _playerInfo.AddCardInfo(_cardChoose.ElementAt(choosePoint));
        for(int i = 0; i < _destinationCount; i++){
            if(i == choosePoint){
                //選んだカードのアニメーション
                _destinationViewUIs[i].UseThisCardAnimation();
            }else{
                //選んでいないカードのアニメーション
                _destinationViewUIs[i].CleanThisCardAnimation();
            }
        }
        //Wait();
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
