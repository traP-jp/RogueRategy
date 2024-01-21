using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EnergyManager : MonoBehaviour
{
    [SerializeField] int maxEnergy;
    [SerializeField] Sprite[] energyImages;
    
    private Image energyBase;
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
                DisplayEnergy();
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
        //変化させる対象のImageを選択
        energyBase = gameObject.GetComponent<Image>();
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

    void DisplayEnergy()
    {
            energyBase.sprite = energyImages[nowEnergyProperty];
    }
}
