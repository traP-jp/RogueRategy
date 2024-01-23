using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] float playerVelocity;
    [SerializeField] int playerMaxHP;
    [SerializeField] PlayerHPUpdater playerHPUpdater;
    public int playerHPProperty
    {
        get
        {
            return playerHP;
        }
        set
        {
            if(value >= 0 && value <= playerMaxHP)
            {
                playerHP = value;
                playerHPUpdater.UpdateHPTank(value);
            }
            else
            {
                if (value < 0) playerHP = 0;
                if (value > playerMaxHP) playerHP = playerMaxHP;
                playerHPUpdater.UpdateHPTank(playerHP);
            }
        }
    }
    int playerHP;

    #region InputSystem関係
    GameInputs gameInputs;
    private void OnEnable()
    {
        gameInputs = new GameInputs();
        gameInputs.Enable();
    }
    private void OnDisable()
    {
        gameInputs.Disable();
    }
    #endregion


    private void Start()
    {
        //プレイヤーHPの初期化(実際は常にHPMaxスタートではない)
        playerHPProperty = playerMaxHP-10;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameInputs.BattleScene.Up.IsPressed())
        {
            transform.position = Vector2.up * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }
        if (gameInputs.BattleScene.Down.IsPressed())
        {
            transform.position = Vector2.down * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }       
        if (gameInputs.BattleScene.Left.IsPressed())
        {
            transform.position = Vector2.left * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }
        if (gameInputs.BattleScene.Right.IsPressed())
        {
            transform.position = Vector2.right * playerVelocity * Time.deltaTime + (Vector2)transform.position;
        }

        
    }
}
