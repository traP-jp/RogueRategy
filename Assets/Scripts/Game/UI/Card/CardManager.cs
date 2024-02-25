using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] float cardPositionX;
    [SerializeField][Header("カードの高さ")] float cardHeight;
    [SerializeField] [Header("一番下のカードの座標")]float bottomPositionY;
    [SerializeField][Header("表示するカードの個数")] int displayMaxCount;
    [SerializeField] CardInfo[] nowDeck;//今のデッキの順番を指定
    [SerializeField] EnergyManager energyManager;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform unitTransform;

    [SerializeField] PlayerStatus playerStatus;//仮置き
    Card[] nowDisplayCards;
    int topCardIndex = 0;//今のトップカードのnowDeckでのインデックスを表す
    private void Start()
    {
        //初期化
        nowDisplayCards = new Card[displayMaxCount];
        for(int index = 0;index < displayMaxCount; index++)
        {
            
            nowDisplayCards[index] = GenerateDefaultCard(nowDeck[index % nowDeck.Length]);
        }
        UpdateCardDisplay();
    }
    private void Update()
    {
        //仮置き
        if (nowDisplayCards[0].cost + playerStatus.costDiffAmount <= energyManager.nowEnergyProperty)
        {
            energyManager.nowEnergyProperty -= nowDisplayCards[0].cost + playerStatus.costDiffAmount;
            CardMovement();
        }
    }

    void CardMovement()
    {
        PlayTopCard();
        DeleteTopCard();
        GenerateNextCard();
        UpdateCardDisplay();
        
    }
    
    void PlayTopCard()
    {
        nowDisplayCards[0].cardInfo.cardEffectInfo.Process();
        BuffManager.Instance.NoticeCardUse();
    }
    void DeleteTopCard()
    {
        // トップカードの消去
        nowDisplayCards[0].Vanish();
        //トップカードが空いた分を詰める
        for(int index = 0;index < displayMaxCount - 1; index++)
        {
            nowDisplayCards[index] = nowDisplayCards[index + 1];
        }
       
    }
    void UpdateCardDisplay()
    {
        //カードの位置の更新
        for(int index = 0;index < displayMaxCount; index++)
        {
            nowDisplayCards[index].cardObject.transform.DOMove(new Vector2(cardPositionX, bottomPositionY + cardHeight * index),0.5f);
        }
    }

    void GenerateNextCard()
    {
        //cardInfoに基づいたカードを生成し、nowDisplayCards[index]に代入
        //トップカードのインデックスの更新
        topCardIndex = (topCardIndex + 1) % nowDeck.Length;
        //次に引くカードのインデックスの導出
        int nextCardIndex = (topCardIndex + displayMaxCount - 1) % nowDeck.Length;
        nowDisplayCards[displayMaxCount - 1] = GenerateDefaultCard(nowDeck[nextCardIndex]);
        
    }

    Card GenerateDefaultCard(CardInfo cardInfo)
    {
        //CardInfoのデータから初期状態のCardを生成
        Card resultCard = new Card();
        resultCard.cardInfo = cardInfo;
        resultCard.cost = cardInfo.defaultCost;
        GameObject cardObject = Instantiate(cardPrefab, transform);
        // GameObject cardObject = Instantiate(cardPrefab, new Vector2(cardPositionX, bottomPositionY + cardHeight * displayMaxCount),Quaternion.identity);
        resultCard.cardObject = cardObject;
        cardObject.GetComponent<CardDisplayUpdater>().cardGraphic.sprite = cardInfo.sprite;
        
        return resultCard;
    }

    public void SetNowDeck(CardInfo[] inputDeck)
    {
        //戦闘開始時のデッキの初期化に利用
        nowDeck = inputDeck;
    }
}
    