using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectProcessor : SingletonMonoBehaviour<CardEffectProcessor>
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform playersUnitParentTransform;
    //カード効果を実行する役割を持つ
    public void GenerateUnitOnPlayer(GameObject unitObject)
    {
        Instantiate(unitObject, playerTransform.position, Quaternion.identity, playersUnitParentTransform);
    }
}
