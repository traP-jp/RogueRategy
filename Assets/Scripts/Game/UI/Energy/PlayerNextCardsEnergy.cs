using UnityEngine;
using UnityEngine.UI;

public class PlayerNextCardsEnergy : MonoBehaviour
{
	[SerializeField] EnergyManager energyManager;
	[SerializeField] CardManager cardManager;
    [SerializeField] Slider costRatioSlider;
    private void Update()
    {
        costRatioSlider.value = energyManager.nowEnergyFloat / cardManager.GetTopCardCost();
    }
}

