using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitDamageNum : MonoBehaviour
{
    private TextMeshPro _displaydamage;
    private RectTransform _rectTransform;
    private Vector3 _initPosition;
    public float DamageNum
    {
        get => DamageNum;
        set=>_displaydamage.text = value.ToString();
    }

    public Transform DamagePosition
    {
        set
        {
            _rectTransform.position = (Vector2)Camera.main.WorldToScreenPoint(value.position) + Vector2.up*50;
            _displaydamage.rectTransform.position = _rectTransform.position;
            _initPosition = _rectTransform.position;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _displaydamage = gameObject.AddComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        _displaydamage.rectTransform.position+=new Vector3(0f,1f,0f);
        if (_displaydamage.rectTransform.position.y > _initPosition.y+80f)
        {
            Destroy(gameObject);
        }
    }
}
