using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCardPrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;

    public void SetPrice(int price)
    {
        _priceText.text = price.ToString();
    }
}
