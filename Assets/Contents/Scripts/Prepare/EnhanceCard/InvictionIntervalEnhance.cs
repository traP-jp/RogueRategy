using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Player;
[System.Serializable]
public class InvictionIntervalEnhance : IEnhanceInterface
{
    [SerializeField] private float _enhanceValue = 1;
    public void EnhancePlayer(PlayerInfoData playerInfo)
    {
        playerInfo.InvictionInterval += _enhanceValue;
    }
}
