using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestinationController : MonoBehaviour
{
    //InputSystem動作のサンプル
    //このスクリプトは最終的に消してください
    
    GameInputs _gameInputs;
    IPrepareSceneInterface prepareSceneInterface;

    public void SetPrepareSceneInterface(IPrepareSceneInterface prepareSceneInterface){
        this.prepareSceneInterface = prepareSceneInterface;
    }
    void OnEnable()
    {
        _gameInputs = new GameInputs();
        _gameInputs.PrepareScene.Up.performed += UpHoge;
        _gameInputs.PrepareScene.Down.performed += DownHoge;
        _gameInputs.PrepareScene.Decide.performed += DecideHoge;
        _gameInputs.PrepareScene.Left.performed += LeftHoge;
        _gameInputs.PrepareScene.Right.performed += RightHoge;
        _gameInputs.Enable();
    }

    void OnDisable()
    {
        _gameInputs.PrepareScene.Up.performed -= UpHoge;
        _gameInputs.PrepareScene.Down.performed -= DownHoge;
        _gameInputs.PrepareScene.Decide.performed -= DecideHoge;
        _gameInputs.PrepareScene.Left.performed -= LeftHoge;
        _gameInputs.PrepareScene.Right.performed -= RightHoge;
        _gameInputs.Dispose();
    }

    void UpHoge(InputAction.CallbackContext context)
    {
        prepareSceneInterface.OnUp();
    }
    void DownHoge(InputAction.CallbackContext context)
    {
        prepareSceneInterface.OnDown();
    }
    void DecideHoge(InputAction.CallbackContext context)
    {
        prepareSceneInterface.OnDecide();
    }
    void LeftHoge(InputAction.CallbackContext context)
    {
        prepareSceneInterface.OnLeft();
    }
    void RightHoge(InputAction.CallbackContext context)
    {
        prepareSceneInterface.OnRight();
    }

}
