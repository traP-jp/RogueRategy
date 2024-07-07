using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using TMPro;
using UnityEngine;

public class UnitDamageNum : MonoBehaviour
{
    public GameObject Displaydamageprehab
    {
        get;
        set;
    }

    private GameObject _displaydamage;
    
    private TextMeshProUGUI _displaydamagetext;
    private RectTransform _rectTransform;
    private Vector3 _initPosition;
    private bool _issetuped=false;


    public RectTransform _canvas
    {
        get;
        set;
    }
    public float DamageNum
    {
        get => DamageNum;
        set { if(_issetuped) _displaydamagetext.text = value.ToString(); }
    }

    public Transform DamagePosition
    {
        set
        {
            _displaydamagetext.rectTransform.position = (Vector2)Camera.main.WorldToScreenPoint(value.position) + Vector2.up*50;
            _initPosition = _displaydamagetext.rectTransform.position;
        }
    }
    
    // Start is called before the first frame update
    public void Inst()
    {
        _displaydamage=Instantiate(Displaydamageprehab, _canvas);
        
        _displaydamagetext = _displaydamage.GetComponent<TextMeshProUGUI>();
        Debug.Log(_displaydamage);
        Debug.Log(_displaydamagetext);
        _issetuped = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (_issetuped)
        {
            _displaydamagetext.rectTransform.position += new Vector3(0f, 1f, 0f);
            if (_displaydamagetext.rectTransform.position.y > _initPosition.y + 160f)
            {

            }
        }
    }
}
