using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Game.Player;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;
public class CoinShower : MonoBehaviour
{
    TextMeshProUGUI _text;
    [SerializeField] private PlayerInfoData _playerInfoData;
    [SerializeField] GameObject _coin;
    [SerializeField] Transform _coinPosition;
    int _coinCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        _text = this.GetComponentInChildren<TextMeshProUGUI>();
        //イベントを購読
        _playerInfoData.OnCoinInfoDataChanged += UseCoin;
        
    }

    public void UseCoin(){
        _playerInfoData.Money = _playerInfoData.Money;
        _text.text = _playerInfoData.Money.ToString();
        CoinAnimation().Forget();
    }
    public async UniTask CoinAnimation(){
        for (int i = 0; i < _coinCount; i++)
        {
            GameObject coinObj = Instantiate(_coin,this.transform.position,Quaternion.identity,_coinPosition);
            coinObj.transform.DOMove(new Vector3(1170,420,0),0.5f).SetEase(Ease.OutQuad).OnComplete(()=>Destroy(coinObj));
            await UniTask.Delay(100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
