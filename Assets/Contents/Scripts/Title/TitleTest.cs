using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleTest : MonoBehaviour
{
    //InputSystem動作のサンプル
    //このスクリプトは最終的に消してください
    
    GameInputs _gameInputs;
    void OnEnable()
    {
        _gameInputs = new GameInputs();
        _gameInputs.TitleScene.Up.performed += UpHoge;
        _gameInputs.Enable();
    }

    void OnDisable()
    {
        _gameInputs.TitleScene.Up.performed -= UpHoge;
        _gameInputs.Dispose();
        Debug.Log("A");
    }

    void UpHoge(InputAction.CallbackContext context)
    {
        Debug.Log("上キーが押された");
    }

    void Update()
    {
        if (_gameInputs.TitleScene.Down.IsPressed())
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
