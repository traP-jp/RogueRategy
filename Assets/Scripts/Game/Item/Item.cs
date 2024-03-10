using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemExplanation;
    [SerializeReference, SubclassSelector] public CardEffect.ICardEffectBundle itemEffectInfo;
    public Sprite itemIcon;
}
