using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSelectManager : MonoBehaviour
{
    //InputSystem動作のサンプル
    //このスクリプトは最終的に消してください
    
    GameInputs _gameInputs;
    IMenuSelectInterface _menuSelectInterface;
    void Start()
    {
        _menuSelectInterface = GetComponentInChildren<IMenuSelectInterface>();
    }
    void OnEnable()
    {
        _gameInputs = new GameInputs();
        _gameInputs.TitleScene.Up.performed += UpHoge;
        _gameInputs.TitleScene.Down.performed += DownHoge;
        _gameInputs.TitleScene.Decide.performed += DecideHoge;
        _gameInputs.Enable();
    }

    void OnDisable()
    {
        _gameInputs.TitleScene.Up.performed -= UpHoge;
        _gameInputs.TitleScene.Down.performed -= DownHoge;
        _gameInputs.TitleScene.Decide.performed -= DecideHoge;
        _gameInputs.Dispose();
        Debug.Log("A");
    }

    void UpHoge(InputAction.CallbackContext context)
    {
        _menuSelectInterface.OnUp();
    }
    void DownHoge(InputAction.CallbackContext context)
    {
        _menuSelectInterface.OnDown();
    }
    void DecideHoge(InputAction.CallbackContext context)
    {
        _menuSelectInterface.OnDecide();
    }

}
