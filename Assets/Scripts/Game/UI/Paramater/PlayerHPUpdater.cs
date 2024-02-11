using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUpdater : MonoBehaviour
{
    [SerializeField] Sprite[] HPTankSprites;
    Image HPTankImage;
    private void Awake()
    {
        HPTankImage = GetComponent<Image>();
    }
    public void UpdateHPTank(int HP)
    {
        HPTankImage.sprite = HPTankSprites[HP];
    }
}
