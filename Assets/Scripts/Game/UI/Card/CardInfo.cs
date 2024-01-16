using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardInfo")]
public class CardInfo:ScriptableObject
{
    //ここにカードの情報を入れる
    public Sprite sprite;
    public int defaultCost;
    public string cardExplanation;
    [SerializeReference,SubclassSelector] public  CardEffect.ICardEffectBundle cardEffectInfo;
    
}

