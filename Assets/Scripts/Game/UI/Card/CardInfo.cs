using System.Collections;
using System.Collections.Generic;
using CardEffect;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardInfo")]
public class CardInfo:ScriptableObject
{
    //ここにカードの情報を入れる
    public Sprite sprite;
    public Sprite cardimage;
    public int defaultCost;
    public string cardName;
    public string cardExplanation;
    [SerializeReference] public  CardEffectBundle cardEffectInfo;
    
}