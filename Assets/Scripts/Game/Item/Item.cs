using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [SerializeReference, SubclassSelector] public CardEffect.ICardEffectBundle itemEffectInfo;
    public Sprite itemIcon;
}
