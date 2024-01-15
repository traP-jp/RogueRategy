using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    //その場の変化含めた情報を持つ
    //Attack,HP,など
   [HideInInspector]public GameObject cardObject;//カード自体のゲームオブジェクト
    public CardInfo cardInfo;
    public int cost;//エネルギーコスト

    
}
