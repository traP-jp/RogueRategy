using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
[System.Serializable]
public class CoinCollectEfficiencyEnhance : IEnhanceInterface
{
    [SerializeField] private float _enhanceValue = 1;
    public void EnhancePlayer(PlayerInfoData playerInfo)
    {
        playerInfo.CoinCollectEfficiency += _enhanceValue;
    }
}
