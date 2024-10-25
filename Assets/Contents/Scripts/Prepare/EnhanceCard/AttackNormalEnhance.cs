using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
[System.Serializable]
public class AttackNormalEnhance : IEnhanceInterface
{
    [SerializeField] private int _enhanceValue = 1;
    public void EnhancePlayer(PlayerInfoData playerInfo)
    {
        playerInfo.AttackNormal += _enhanceValue;
    }
}
