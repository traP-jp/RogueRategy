using System.Collections;
using System.Collections.Generic;
using CardEffect;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public bool isUseItemOnPlayer = true;//アイテムを使用した際にプレイヤーの座標に使用されるか
    //この値がfalseの時、マウスの座標にアイテムを使用します
    public string itemName;
    public string itemExplanation;
    [SerializeReference,SubclassSelector] public ICardEffect[] itemEffectInfo;
    public Sprite itemIcon;
}
