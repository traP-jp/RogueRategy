using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class EnergyManager : MonoBehaviour
{
    [SerializeField] int maxEnergy;
    [SerializeField] Sprite[] energyImages;
    
    private Image energyBase;
    public float energyRecoverInterval = 1;
    ReactiveProperty<int> nowEnergy = new ReactiveProperty<int>(0);
    public float nowEnergyFloat = 0;
    

    private void Awake()
    {
        energyBase = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        nowEnergy.Subscribe(x => energyBase.sprite = energyImages[x]).AddTo(this);
    }

    private void Update()
    {
        //エナジーを一定時間おきに回復させる
        ChangeEnergyValue(Time.deltaTime / energyRecoverInterval);
    }

    public void ChangeEnergyValue(float value)
    {
        //valueだけエナジーを増減する
        nowEnergyFloat += value;
        nowEnergy.Value = Mathf.Clamp(Mathf.RoundToInt(nowEnergyFloat), 0, 15);
    }
}
