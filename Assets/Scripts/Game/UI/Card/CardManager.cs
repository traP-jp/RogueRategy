using System.Collections;
using System.Collections.Generic;
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
        if (nowDisplayCards[0].cost <= energyManager.nowEnergyProperty)
        {
            energyManager.nowEnergyProperty -= nowDisplayCards[0].cost;
            PlayTopCard();
            DeleteTopCard();
            GenerateNextCard();
            UpdateCardDisplay();
        }
    }
    void PlayTopCard()
    {
        nowDisplayCards[0].cardInfo.cardEffect.Process();
        

    }
    void DeleteTopCard()
    {

        
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
            nowDisplayCards[index].cardObject.transform.position = new Vector2(cardPositionX, bottomPositionY + cardHeight * index);
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
        GameObject cardObject = Instantiate(cardPrefab, this.transform);
        resultCard.cardObject = cardObject;
        cardObject.GetComponent<CardDisplayUpdater>().cardGraphic.sprite = cardInfo.sprite;
        return resultCard;
    }
}
    