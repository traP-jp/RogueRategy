using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitDamageNum : MonoBehaviour
{
    private TextMeshPro displaydamage;
    private RectTransform rectTransform;
    public float DamageNum
    {
        get => DamageNum;
        set=>displaydamage.text = value.ToString();
    }

    public Transform DamagePosition
    {
        set
        {
            rectTransform.position = (Vector2)Camera.main.WorldToScreenPoint(value.position) + Vector2.up*50;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
