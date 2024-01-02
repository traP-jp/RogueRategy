using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EnergyManager : MonoBehaviour
{
    [SerializeField] int maxEnergy;
    [SerializeField] Image[] energyImages;
    [SerializeField] Sprite energyOnSprite;
    [SerializeField] Sprite energyOffSprite;
    public float energyRecoverInterval = 1;
    int nowEnergy = 0;
    public int nowEnergyProperty
    {
        get
        {
            return nowEnergy;
        }
        set
        {
            if(value >= 0 && value <= maxEnergy)
            {
                nowEnergy = value;
                displayEnergy();
            }
            else
            {
                if (value < 0) nowEnergy = 0;
                if (value > maxEnergy) nowEnergy = maxEnergy;
                throw new ArgumentOutOfRangeException();
            }
        }
    }


    private void Start()
    {
        StartCoroutine(recoverEnergyConstantly());
    }

    IEnumerator recoverEnergyConstantly()
    {
        while (true)
        {
            yield return new WaitForSeconds(energyRecoverInterval);
            try
            {
                nowEnergyProperty = nowEnergyProperty + 1;
            }
            catch
            {

            }
        }
        
       
    }

    void displayEnergy()
    {
        for(int index = 0;index < maxEnergy; index++)
        {
            energyImages[index].sprite = index < nowEnergy ? energyOnSprite : energyOffSprite;
        }
       
    }
}
