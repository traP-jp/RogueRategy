using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
[System.Serializable]
public class AttackDefaultEnhance : IEnhanceInterface
{
    [SerializeField] private int _enhanceValue = 1;
    public void EnhancePlayer(PlayerInfoData playerInfo)
    {
        playerInfo.AttackDefault += _enhanceValue;
    }
}
